using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using CharityMobile.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Prism.Services;
using CharityMobile.Services;
using CharityMobile.DAL;

namespace CharityMobile.ViewModels
{
    public class NeedsPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        IPageDialogService _pageDialogService;

        private NeedService _needService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _IsLoading = true;
        public bool IsLoading
        {
            get { return _IsLoading; }
            set { SetProperty(ref _IsLoading, value); }
        }

        public ObservableCollection<Need> _needsCollection;
        public ObservableCollection<Need> NeedCollection
        {
            get
            {
                return _needsCollection;
            }
            private set
            {
                _needsCollection = value;
                OnPropertyChanged("NeedCollection");
            }
        }

        public ICommand NavigationCommand { get; set; }
        
        public NeedsPageViewModel(NeedService model, INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            _needService = model;
            NavigationCommand = new DelegateCommand<string>(Navigation);
        }
       
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Task ignoreTask = LoadDataAsync();
        }
        private void Navigation(string id)
        {
            Title = id;
            string navPath = "MainMasterDetailPage/MainNavigationPage/NeedPage?Id=" + id;
            _navigationService.NavigateAsync(navPath);
        }
        
        private async Task LoadDataAsync()
        {
            ObservableCollection<Need> needs = new ObservableCollection<Need>();
            try
            {
                var data = await _needService.GetAllAsync();
                IsLoading = false;
                foreach (var need in data)
                    needs.Add(need);
                NeedCollection = needs;
                Title = "Кількість соціальних потреб: " + NeedCollection.Count;
            }
            catch (HttpCodeRequestException ex)
            {
                await _pageDialogService.DisplayAlertAsync("Помилка", ex.InnerMessage, "Гаразд");
            }
            catch (Exception ex)
            {
                await _pageDialogService.DisplayAlertAsync("Помилка", ex.Message, "Гаразд");
            }
            IsLoading = false;
        }
    }
}
