using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using neo.pcl.Pages;

namespace neo.pcl
{
    class MainPageVM: ViewModelBase
    {
        private MainMenuVM _menuViewModel;

        public MainMenuVM MenuViewModel
        {
            get
            {
                return _menuViewModel;
            }

            set
            {
                _menuViewModel = value;
                RaisePropertyChanged(() => MenuViewModel);
            }
        }

        public MainPageVM(MainMenuVM menuViewModel)
        {
            _menuViewModel = menuViewModel;
        }

        public override Task InitializeAsync(object navigationData)
        {
            return Task.WhenAll
                (
                    _menuViewModel.InitializeAsync(navigationData),
                    NavigationService.NavigateToAsync<HomePageVM>()
                );
        }
    }
}
