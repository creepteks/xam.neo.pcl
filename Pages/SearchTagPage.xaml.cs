using Plugin.Geolocator;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Tag.Core.Utils;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace Tag.Core.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchTagPage : ContentPage
    {
        #region fields & props
        // viewModel
        private SearchTagPageVM _viewModel;
        private int ScrollMinLimit = 0;
        private int ScrollMaxLimit = 190;
        #region Map fields
        Pin userPin = new Pin
        {
            Type = PinType.Place,
            Label = "موقعیت شما",
            ZIndex = 1
        };

        #endregion
        #endregion

        public SearchTagPage()
        {
            InitializeComponent();
            InitializeMap();
            SetupRelativeView();
            _viewModel = DependencyInjector.instance.Resolve<SearchTagPageVM>();
        }

        private void SetupRelativeView()
        {
            relativeLayout.Children.Add(autoCmpltion,
                yConstraint: Constraint.RelativeToView(mainStack,
                                                        (relLayout, view) =>
                                                        {
                                                            StackLayout stack = view as StackLayout;
                                                            float height = (float)(stack.Children[0].Height + stack.Children[1].Height);
                                                            return height;
                                                        }));
        }


        #region UI Events

        [System.Obsolete("We do not use Entry anymore. We use SearchBar instead")]
        private void SearchTagTxt_Completed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TagSearchBar.Text))
                return;
            TagSearchBar.Text = "";
        }

        private void TagSearchBar_UpdateSuggestions(object sender, TextChangedEventArgs e)
        {
            AutoCompleteUpdate((sender as SearchBar).Text);
        }

        private void TagSearchBar_AddTag(object sender, TextChangedEventArgs e)
        {
            AddTag((sender as SearchBar).Text);

        }

        private void AddTag(string tag)
        {

            // 1: we add the tag to the stacklayout through a Label
            // #revise: change Label with a custom control which supports click, has a delete Btn, etc.
            Label lbl = new Label()
            {
                // #revise: add some style
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.End
            };

            lbl.Text = tag;
            SearchTagsHolder_SL.Children.Add(lbl);
            // 2: we clear the entered text to make room for new inquiries
            if (!string.IsNullOrWhiteSpace(TagSearchBar.Text))
            {
                TagSearchBar.Text = "";
            }
            // 3: we set the focus back to searchfield, just in case...
            TagSearchBar.Focus();

            //// 4: Make the map visible if needed
            //if (SearchTagsHolder_SL.Children.Count > 0 && SearchTagsHolder_SL.Children.Count < 2)
            //{
            //    Task.Run(async () => await FadeInMap());
            //}
        }


        private void AutoCompleteUpdate(string filter)
        {
            AutoCmpltion_LstVw.BeginRefresh();
            if (string.IsNullOrWhiteSpace(filter))
            {
                AutoCmpltion_LstVw.ItemsSource = null;
                SearchTagsHolder_SL.Opacity = 1;
            }
            else
            {
                SearchTagsHolder_SL.Opacity = 0;
                AutoCmpltion_LstVw.ItemsSource = _viewModel.AutoCompleteSuggestions.Where(x => x.ToLower().Contains(filter.ToLower()));
            }
            AutoCmpltion_LstVw.EndRefresh();
        }

        private void AutoCmpltion_LstVw_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            AddTag((sender as ListView).SelectedItem.ToString());
            AutoCmpltion_LstVw.SelectedItem = null;

        }
        private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            var val = MathHelper.ReMap(e.ScrollY, ScrollMinLimit, ScrollMaxLimit, 1, 0);
            this.questionLabel.Scale = val;
            this.TagSearchBar.Scale = val;
            this.SearchTagsHolder_SL.Scale = val;
        }
        #endregion

        #region Map Funx

        // #refactor
        private void InitializeMap()
        {
            Plugin.Geolocator.Abstractions.Position pos = DependencyInjector.instance.Resolve<ILocationService>().currentPos;
            map.InitialCameraUpdate = CameraUpdateFactory.NewPositionZoom(new Position(pos.Latitude, pos.Longitude), 40d);
            // create a pin for current position of the user
            userPin.Icon = new Func<BitmapDescriptor>(() =>
            {
                // #refactor
                string icon = "userpin.png";
                var assembly = typeof(SearchTagPage).GetTypeInfo().Assembly;
                var stream = assembly.GetManifestResourceStream($"Tag.Core.{icon}");
                return BitmapDescriptorFactory.FromStream(stream);
            }).Invoke();
            userPin.Position = new Position(pos.Latitude, pos.Longitude);
            userPin.IsDraggable = true;
            userPin.IsVisible = true;
            map.Pins.Add(userPin);
        }
        #endregion
    }
}