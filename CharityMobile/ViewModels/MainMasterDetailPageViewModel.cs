using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;

namespace CharityMobile.ViewModels
{
    public class MainMasterDetailPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        public ICommand NavigationCommand { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public MainMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigationCommand = new DelegateCommand<string>(Navigation);
        }
        
        private void Navigation(string parameter)
        {
            _navigationService.NavigateAsync(parameter);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
