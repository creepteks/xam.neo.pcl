using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Plugin.Geolocator;
using System.IO;
using Acr.UserDialogs;

namespace Tag.Core
{
    class HomePageVM : ViewModelBase, IObserver<IBaseAction>
    {
        //Dependencies
        PersonalState personalState = DependencyInjector.instance.Resolve<PersonalState>();

        // Bindable fields, properties and methods

        //private string _personName;
        public string PersonName
        {
            get { return personalState.name; }
            set
            {
                //_personName = value;
                RaisePropertyChanged(() => PersonName);
            }

        }
        FriendsActivity _friendsActivities = new FriendsActivity();
        public FriendsActivity FriendActivities
        {
            get { return _friendsActivities; }

            set
            {
                RaisePropertyChanged(() => FriendActivities);
            }
        }

        List<Suggestion> _recommendedForYou = new List<Suggestion>();
        public List<Suggestion> RecommendedForYou
        {
            get { return _recommendedForYou; }
            set
            {
                RaisePropertyChanged(() => RecommendedForYou);
            }
        }

        private List<Shop_Simplified> _favoriteShops = new List<Shop_Simplified>();

        public List<Shop_Simplified> FavoriteShops
        {
            get { return _favoriteShops; }
            set { _favoriteShops = value; }
        }

        public ICommand SelectRecommendedCommand => new Command<Suggestion>(SuggestionSelect);
        private async void SuggestionSelect(Suggestion sugg)
        {
            await UserDialogs.Instance.AlertAsync(sugg.suggestionName);
        }
        public ICommand SelectFavShopCommand => new Command<Shop_Simplified>(ShopSelect);
        private async void ShopSelect(Shop_Simplified shop)
        {
            await UserDialogs.Instance.AlertAsync(shop.Name);
        }

        public ICommand SearchForTagCommand => new Command(SearchForTag);

        private void SearchForTag(object obj)
        {
            NavigationService.NavigateToAsync<SearchTagPageVM>();
        }


        // methods
        public HomePageVM()
        {
            personalState.AddObserver(this, TypeOfObserver.ClientSide);
            // #debug
            MockupData();
            //test = JsonConvert.SerializeObject(SuggestionsForYou, Formatting.Indented);
            //var test2 = JsonConvert.DeserializeObject(test) as List<Suggestion>;
            //Purchase newP = new Purchase();
            //test = JsonConvert.SerializeObject(newP);
            //var locator = CrossGeolocator.Current;
            //locator.DesiredAccuracy = 5;
            //var position = locator.GetPositionAsync(timeoutMilliseconds: 10000);
            //test = string.Format("timestamp {0}\nlatitude {1}\nlongitude {2}");
        }

        private void MockupData()
        {
            for (int i = 0; i < 10; i++)
            {
                RecommendedForYou.Add(new Suggestion());
            }
            for (int i = 0; i < 10; i++)
            {
                FavoriteShops.Add(new Shop_Simplified());
            }
        }
        public void UpdateViewModel(IBaseAction action)
        {
            try
            {
                IFatAction<PersonalActionType, object> act = action as IFatAction<PersonalActionType, object>;
                if (act.Type == PersonalActionType.NameUpdate)
                {
                    PersonName = PersonalState.instance.name;
                }
            }
            catch (Exception)
            {
                // pass by!!!
            }
        }

    }
}
