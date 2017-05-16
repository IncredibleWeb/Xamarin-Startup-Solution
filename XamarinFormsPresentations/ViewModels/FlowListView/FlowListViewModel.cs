using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class FlowListViewModel : BaseViewModel
	{
		ObservableCollection<FlowModel> flowModels;

		public ObservableCollection<FlowModel> FlowModels
		{
			get { return flowModels; }
			set
			{
				flowModels = value;
				OnPropertyChanged("FlowModels");
			}
		}

		public FlowListViewModel()
		{
			FlowModels = new ObservableCollection<FlowModel>
			{
				new FlowModel{
					Title="Picture 1",
					ThumbnailUrl="http://e0.365dm.com/16/02/16-9/20/ferrari-formula-one_3420142.jpg?20160223095033"
				},
				new FlowModel{
					Title="Picture 2",
					ThumbnailUrl="https://upload.wikimedia.org/wikipedia/commons/1/14/2010_Malaysian_GP_opening_lap.jpg"
				},
				new FlowModel{
					Title="Picture 3",
					ThumbnailUrl="http://e1.365dm.com/16/02/16-9/20/mclaren-formula-one_3420151.jpg?20160223100221"
				},
				new FlowModel{
					Title="Picture 4",
					ThumbnailUrl="http://media.cdn.mclaren.com/images/articles/livestream/crop/_X4I1532_Cin0fq3.jpg"
				},
				new FlowModel{
					Title="Picture 5",
					ThumbnailUrl="http://media.cdn.mclaren.com/images/articles/livestream/crop/_X4I1532_Cin0fq3.jpg"
				}
			};
		}
	}
}
