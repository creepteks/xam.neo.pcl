using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neo.pcl
{
    class MainMenuVM: ViewModelBase
    {
        private IAuthenticationService _authService;

        public MainMenuVM(IAuthenticationService authenticationService)
        {
            _authService = authenticationService;
        }
    }
}
