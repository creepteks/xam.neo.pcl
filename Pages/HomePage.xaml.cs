using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tag.Core.Utils;
using Xamarin.Forms;

namespace Tag.Core.Pages
{
    public partial class HomePage : ContentPage
    {
        private const int ScrollMinLimit = 0;
        private const int ScrollMaxLimit = 190;
        public HomePage()
        {
            SetUpDependencies();
            NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent();
            this.mainScrollView.Scrolled += MainScrollView_Scrolled;
            Task.Run(async () => await DoAnimations());
            

            //ReduxStore.instance.Initialize();
            //var some = ReduxStore.instance.ToString();
            //TextLabel.Text = "Salam";
            //PushMe.Clicked += (e, args) =>
            //{
            //    ReduxStore.instance.Dispatch(new PersonalAction()
            //                                    .SetObservation(TypeOfObserver.ClientSide, TypeOfObserver.ServerSide)
            //                                    .SetContent("akbar")
            //                                    .SetType(PersonalActionType.NameUpdate));
            //};
            //codecom.Clicked += (e, args) =>
            //{
            //    ReduxStore.instance.Dispatch(new PersonalAction()
            //                                    .SetObservation(TypeOfObserver.ClientSide, TypeOfObserver.ServerSide)
            //                                    .SetContent("akbar")
            //                                    .SetType(PersonalActionType.NameUpdate));
            //};
        }

        private async Task DoAnimations()
        {
            //await RecForYouList.Scroll_To_RTL_Start();
            //await FavoriteShopsList.Scroll_To_RTL_Start();
        }

        private void MainScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            var val = MathHelper.ReMap(e.ScrollY, ScrollMinLimit, ScrollMaxLimit, 1, 0);

            this.infoPanel.Scale = val;
        }

        private void SetUpDependencies()
        {
            
        }
    }
}
