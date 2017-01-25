using Prism.Mvvm;
using Prism.Navigation;
using System.Windows.Input;

namespace CharityMobile.ViewModels
{
    public class NeedPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public ICommand NavigationCommand { get; set; }
        public NeedPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = (string)parameters["Id"];
        }
    }
}
