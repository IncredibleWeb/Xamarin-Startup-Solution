using System;
using System.Collections.Generic;

namespace XamarinFormsPresentations
{
	public class GalleryViewModel : BaseViewModel
	{
		List<string> imageUrls;

		public List<string> ImageUrls
		{
			get { return imageUrls; }
			set
			{
				imageUrls = value;
				OnPropertyChanged("ImageUrls");
			}
		}

		public GalleryViewModel()
		{
			ImageUrls = new List<string>
			{				
				"http://e0.365dm.com/16/02/16-9/20/ferrari-formula-one_3420142.jpg?20160223095033",
				"https://upload.wikimedia.org/wikipedia/commons/1/14/2010_Malaysian_GP_opening_lap.jpg",
				"http://e1.365dm.com/16/02/16-9/20/mclaren-formula-one_3420151.jpg?20160223100221",
				"http://media.cdn.mclaren.com/images/articles/livestream/crop/_X4I1532_Cin0fq3.jpg"
			};
		}
	}
}
