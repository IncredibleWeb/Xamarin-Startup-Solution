using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Microsoft.ProjectOxford.Face;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class FaceViewModel : BaseViewModel
	{
		FaceServiceClient faceServiceClient;
		string personGroupId;
		MediaFile image;

		#region Properties

		private string imageUrl;
		public string ImageUrl
		{
			get { return imageUrl; }
			set
			{
				imageUrl = value;
				OnPropertyChanged("ImageUrl");
			}
		}

		private string name;
		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}

		private string age;
		public string Age
		{
			get { return age; }
			set
			{
				age = value;
				OnPropertyChanged("Age");
			}
		}

		private string glasses;
		public string Glasses
		{
			get { return glasses; }
			set
			{
				glasses = value;
				OnPropertyChanged("Glasses");
			}
		}

		private string smile;
		public string Smile
		{
			get { return smile; }
			set
			{
				smile = value;
				OnPropertyChanged("Smile");
			}
		}

		#endregion

		public FaceViewModel()
		{
			faceServiceClient = new FaceServiceClient("1a553bcee0484e51865f2f9cba2d6d23");

			//Train API
			TrainFaceAPI.Execute(null);
		}

		#region Train Face API

		Command trainFaceAPI;

		public Command TrainFaceAPI
		{
			get
			{
				return trainFaceAPI ??
					(trainFaceAPI = new Command(ExecuteTrainFaceAPI));
			}
		}

		async void ExecuteTrainFaceAPI()
		{
			var people = new List<Person>
			{
				new Person{
					FullName="Shaun",
					PhotoUrl="https://scontent-mxp1-1.xx.fbcdn.net/v/t1.0-9/12038495_916990261703186_7575801463680622880_n.jpg?oh=db07dbdb3f728b56460545d3991d1063&oe=58C4A1BF"
				},
				new Person {
					FullName="Katya",
					PhotoUrl="https://scontent-mxp1-1.xx.fbcdn.net/v/t1.0-9/13659191_1380711775279518_6270811927728068493_n.jpg?oh=b143f5356842bb338ab05d24b786b748&oe=58C612CD"
				},
				new Person{
					FullName="Kevin",
					PhotoUrl="https://www.pizza4u.com.mt/media/1005/kevin-farrugia.jpg"
				},
				new Person{
					FullName="Gosia",
					PhotoUrl="https://scontent-mxp1-1.xx.fbcdn.net/v/t1.0-9/10347484_10201839306779156_4563104125806602622_n.jpg?oh=15fdba843aed15636ae0f5ac209ce6e1&oe=58B664D1"
				},	
				new Person{
					FullName="Alberto",
					PhotoUrl="https://trello-attachments.s3.amazonaws.com/568fc6d9a159da4a0a38a6e5/278x359/6f5b8c4486f5d059b9b6f91a0d2c04c4/4a6f310c-a2a1-49e0-8df5-3c859485207c.jpg"
				}
			};

			try
			{

				IsBusy = true;					

				// Step 1 - Create Person Group
				personGroupId = Guid.NewGuid().ToString();
				await faceServiceClient.CreatePersonGroupAsync(personGroupId, "Incredible Web Employees");

				// Step 2 - Add persons (and faces) to person group.
				foreach (var person in people)
				{
					// Step 2a - Create a new person, identified by their name.
					var p = await faceServiceClient.CreatePersonAsync(personGroupId, person.FullName);
					// Step 3a - Add a face for that person.
					await faceServiceClient.AddPersonFaceAsync(personGroupId, p.PersonId, person.PhotoUrl);
				}

				// Step 3 - Train facial recognition model.
				await faceServiceClient.TrainPersonGroupAsync(personGroupId);

				IsBusy = false;
			}
			catch (Exception ex)
			{
				IsBusy = false;
				UserDialogs.Instance.ShowError("Training has not finished");
			}
		}

		#endregion

		#region Take Picture Command

		Command takePictureCommand;

		public Command TakePictureCommand
		{
			get
			{
				return takePictureCommand ??
				(takePictureCommand = new Command(ExecuteTakePictureCommand));
			}
		}

		async void ExecuteTakePictureCommand()
		{
			var currentMediaInstance = CrossMedia.Current;

			await currentMediaInstance.Initialize();

			if (!currentMediaInstance.IsCameraAvailable || !currentMediaInstance.IsTakePhotoSupported)
			{
				Acr.UserDialogs.UserDialogs.Instance.Alert("Your camera is unavailable or unsupported", "Camera Unavailable", "OK");
				return;
			}

			image = await currentMediaInstance.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
			{
				SaveToAlbum = true
			});

			if (image != null)
			{
				ImageUrl = image.Path;
			}
		}

		#endregion

		#region Recognize Picture Command

		Command recognizePictureCommand;

		public Command RecognizePictureCommand
		{
			get
			{
				return recognizePictureCommand ??
				(recognizePictureCommand = new Command(ExecuteRecognizePictureCommand));
			}
		}

		async void ExecuteRecognizePictureCommand()
		{

			var requiredFaceAttributes = new FaceAttributeType[] {
				FaceAttributeType.Age,
				FaceAttributeType.Gender,
				FaceAttributeType.Smile,
				FaceAttributeType.FacialHair,
				FaceAttributeType.HeadPose,
				FaceAttributeType.Glasses};

			using (var stream = image.GetStream())
			{
				UserDialogs.Instance.ShowLoading();

				// Step 4a - Detect the faces in this photo.
				var faces = await faceServiceClient.DetectAsync(stream,
																true,
																returnFaceAttributes: requiredFaceAttributes);

				var smileValue = faces[0].FaceAttributes.Smile;
				var ageValue = faces[0].FaceAttributes.Age;
				var glassesValue = faces[0].FaceAttributes.Glasses;

				var faceIds = faces.Select(face => face.FaceId).ToArray();

				// Step 4b - Identify the person in the photo, based on the face.
				var results = await faceServiceClient.IdentifyAsync(personGroupId, faceIds);
				if (results[0].Candidates.Count() < 1)
				{
					UserDialogs.Instance.ShowError("Could not find the user");
				}
				else
				{
					var result = results[0].Candidates[0].PersonId;

					// Step 4c - Fetch the person from the PersonId and display their name.
					var person = await faceServiceClient.GetPersonAsync(personGroupId, result);

					Name = "Name: " + person.Name;
					Age = "Age: " + ageValue;
					Glasses = "Glasses: " + glassesValue;
					Smile = "Status: " + (smileValue > 0.7 ? "Happy" : "Neutral");

					UserDialogs.Instance.HideLoading();

					UserDialogs.Instance.ShowSuccess($"Person identified is {person.Name}.", 3000);
				}
			}
		}

		#endregion



	}
}
