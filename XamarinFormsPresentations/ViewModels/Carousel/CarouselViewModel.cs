using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormsPresentations
{
    public class CarouselViewModel : BaseViewModel
    {
        private List<string> imageUrls;

        public List<string> ImageUrls
        {
            get { return imageUrls; }
            set
            {
                imageUrls = value;
                OnPropertyChanged("ImageUrls");
            }
        }

        public CarouselViewModel()
        {
            ImageUrls = new List<string>
            {
                "https://www.incredible-web.com/img/logo.png",
                "https://www.incredible-web.com/media/1069/shaun-grech.jpg",
                "https://www.incredible-web.com/media/1070/kevin-farrugia.jpg",
                "https://www.incredible-web.com/media/1092/tag-manager.png",
                "https://www.incredible-web.com/media/1091/awwwards.png",
                "https://www.incredible-web.com/media/1090/css-design-awards.jpg",
                "https://www.incredible-web.com/media/1093/web-summit.png",
                "https://www.incredible-web.com/media/1104/screen-shot-2016-05-03-at-65717-pm.png"
            };  
        }
    }
}
