using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormsPresentations
{
    class QrCodeViewModel : BaseViewModel
    {
        private string qrCodeValue;

        public string QrCodeValue
        {
            get { return qrCodeValue; }
            set
            {
                qrCodeValue = value;
                OnPropertyChanged("QrCodeValue");
            }
        }
    }
}
