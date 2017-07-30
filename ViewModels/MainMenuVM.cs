using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag.Core
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
