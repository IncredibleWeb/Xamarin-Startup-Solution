using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormsPresentations
{
	public class LabelShapesPage : BasePage<LabelShapesViewModel>
    {
        public LabelShapesPage()
        {
            Title = "Shapes of labels";
            base.scrollView.Content = new LabelShapesView();
        }
    }
}
