using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace neo.pcl
{
    public class DependencyInjector
    {
        private readonly IUnityContainer _unityContainer;

        //singleton
        private static readonly DependencyInjector _instance = new DependencyInjector();

        public static DependencyInjector instance
        {
            get { return _instance; }
        }

        //methods
       //constructor
        public DependencyInjector()
        {
            _unityContainer = new UnityContainer();
            //Services, DataServices
            // #note: all of our services and dataservices are definitely singletons. Peace. (Neo)
            RegisterSingleton<IWebsocktClient, TagClient>();
            RegisterSingleton<INavigationService, NavigationService>();
            RegisterSingleton<IAuthenticationService, AuthenticationService>();
            RegisterSingleton<IRestService, RestService>();
            RegisterSingleton<ICryptoService, CryptoService>();
            RegisterSingleton<ILocationService, LocationService>();
            _unityContainer.RegisterType<IDialogService, DialogService>(); // Dialog service is singleton in nature, so we just register its type


            //viewModels
            //_unityContainer.RegisterType(SplashScreen);
            _unityContainer.RegisterType<AuthPageVM>();
            _unityContainer.RegisterType<MainPageVM>();
            _unityContainer.RegisterType<MainMenuVM>();
            _unityContainer.RegisterType<HomePageVM>();
            //_unityContainer.RegisterType<WhatULookingForVM>();
            _unityContainer.RegisterType<SearchTagPageVM>();

            //states
            RegisterSingleton<IState<IFatAction<PersonalActionType, object>>, PersonalState>();
        }
        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _unityContainer.Resolve(type);
        }

        public void Register<T>(T instance)
        {
            _unityContainer.RegisterInstance<T>(instance);
        }

        public void Register<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>();
        }

        public void RegisterSingleton<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>(new ContainerControlledLifetimeManager());
        }
    }
}
