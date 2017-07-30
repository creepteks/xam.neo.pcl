using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace neo.pcl.Pages
{
    //[XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            NavigationPage.SetHasBackButton(this, true);
            InitializeComponent();
        }
    }
}
