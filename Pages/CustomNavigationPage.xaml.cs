using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace neo.pcl.Pages
{
    public partial class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage() : base()
        {
            InitializeComponent();
            SetTransparentToolbar();
        }

        public CustomNavigationPage(Page root): base(root)
        {
            InitializeComponent();
            SetTransparentToolbar();
        }

        private void SetTransparentToolbar()
        {
            BarBackgroundColor = Color.Transparent;
        }
    }
}
