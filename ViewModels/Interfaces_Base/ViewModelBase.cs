using System.Threading.Tasks;

namespace Tag.Core
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {
        protected readonly IDialogService dilgSrv;
        protected readonly INavigationService NavigationService;
        public readonly IRestService rstSrv;
        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public ViewModelBase()
        {
            dilgSrv = DependencyInjector.instance.Resolve<IDialogService>();
            NavigationService = DependencyInjector.instance.Resolve<INavigationService>();
            rstSrv = DependencyInjector.instance.Resolve<IRestService>();
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}