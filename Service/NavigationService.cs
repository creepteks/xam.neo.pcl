using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using neo.pcl.Pages;

namespace neo.pcl
{
    public class NavigationService : INavigationService
    {
        private readonly IAuthenticationService _authService;
        protected readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication
        {
            get
            {
                return Application.Current;
            }
        }
        public CustomNavigationPage Navigation { get; set; }

        public NavigationService(IAuthenticationService authenticationService)
        {
            _authService = authenticationService;
            _mappings = new Dictionary<Type, Type>();
            CreatePageViewModelMappings();
            //CreateMessengerSubscriptions();
        }

        public Task InitializeAsync()
        {
            if (_authService.IsAuthenticated())
            {
                return NavigateToAsync<MainPageVM>();
            }
            else
            {
                return NavigateToAsync<AuthPageVM>();
            }
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            var res = InternalNavigateToAsync(typeof(TViewModel), null);
            return res;
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null);
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage is MainPage)
            {
                var mainPage = CurrentApplication.MainPage as MainPage;
                await mainPage.Detail.Navigation.PopAsync();
            }
            else if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            var mainPage = CurrentApplication.MainPage as MainPage;

            if (mainPage != null)
            {
                mainPage.Detail.Navigation.RemovePage(
                    mainPage.Detail.Navigation.NavigationStack[mainPage.Detail.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);

            if (page is MainPage)
            {
                CurrentApplication.MainPage = page;
            }
            else if (page is AuthPage)
            {
                CurrentApplication.MainPage = new CustomNavigationPage(page);
                // #test
                Navigation = CurrentApplication.MainPage as CustomNavigationPage;
            }
            else if (CurrentApplication.MainPage is MainPage)
            {
                var mainPage = CurrentApplication.MainPage as MainPage;
                var navigationPage = mainPage.Detail as CustomNavigationPage;

                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    navigationPage = new CustomNavigationPage(page);
                    mainPage.Detail = navigationPage;
                }

                // #test
                Navigation = navigationPage;
                mainPage.IsPresented = false;
            }
            else
            {
                var navigationPage = CurrentApplication.MainPage as CustomNavigationPage;

                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    CurrentApplication.MainPage = new CustomNavigationPage(page);
                }
            }
            /* Neo : a work around for MVVM => 
                we have some problems getting the functionality of Page files
                cause we are defining the logic in viewModels, not the pages themeselves,
                but with this workaround, I hope that we can Get some of the functionalities of the pages
                and still have all of the logic in viewModels */
            App.CurrentPage = page; 
            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            ViewModelBase viewModel = DependencyInjector.instance.Resolve(viewModelType) as ViewModelBase;
            Page page = Activator.CreateInstance(pageType) as Page;
            page.BindingContext = viewModel;

            if (page is IPageWithParameters)
            {
                ((IPageWithParameters)page).InitializePageWith(parameter);
            }

            return page;
        }

        private void CreatePageViewModelMappings()
        {
            //_mappings.Add(typeof(CustomRideViewModel), typeof(CustomRidePage));
            //_mappings.Add(typeof(EventSummaryViewModel), typeof(EventSummaryPage));
            //_mappings.Add(typeof(HomeViewModel), typeof(HomePage));
            //_mappings.Add(typeof(LoginViewModel), typeof(LoginPage));
            //_mappings.Add(typeof(PaymentViewModel), typeof(PaymentPage));
            _mappings.Add(typeof(AuthPageVM), typeof(AuthPage));
            _mappings.Add(typeof(SignUpPageVM), typeof(SignUpPage));
            _mappings.Add(typeof(MainPageVM), typeof(MainPage));
            _mappings.Add(typeof(HomePageVM), typeof(HomePage));
            _mappings.Add(typeof(MainMenuVM), typeof(MainMenu));
            //_mappings.Add(typeof(WhatULookingForVM), typeof(WhatULookingFor));
            _mappings.Add(typeof(SearchTagPageVM), typeof(SearchTagPage));



            //if (Device.OS == TargetPlatform.Windows)
            //{
            //    _mappings.Add(typeof(SignUpViewModel), typeof(UwpSignUpPage));

            //    if (Device.Idiom == TargetIdiom.Desktop)
            //    {
            //        _mappings.Add(typeof(UwpMyRidesViewModel), typeof(UwpMyRidesPage));
            //        _mappings.Add(typeof(ProfileViewModel), typeof(UwpProfilePage));
            //    }
            //    else
            //    {
            //        _mappings.Add(typeof(MyRidesViewModel), typeof(MyRidesPage));
            //        _mappings.Add(typeof(ProfileViewModel), typeof(ProfilePage));
            //    }
            //}
            //else
            //{
            //    _mappings.Add(typeof(SignUpViewModel), typeof(SignUpPage));
            //    _mappings.Add(typeof(MyRidesViewModel), typeof(MyRidesPage));
            //    _mappings.Add(typeof(ProfileViewModel), typeof(ProfilePage));
            //}

            //_mappings.Add(typeof(ReportIncidentViewModel), typeof(ReportIncidentPage));
            //_mappings.Add(typeof(BookingViewModel), typeof(BookingPage));
            //_mappings.Add(typeof(MainViewModel), typeof(MainPage));
        }
    }
}