using CharityMobile.DAL;
using CharityMobile.Models;
using CharityMobile.Services;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;

namespace CharityMobile.ViewModels
{
    public class SocialWorkersPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        IPageDialogService _pageDialogService;

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
        private SocialWorkerService _socialWorkerService;

        public ObservableCollection<SocialWorker> _socialWorkerCollection;
        public ObservableCollection<SocialWorker> SocialWorkerCollection
        {
            get
            {
                return _socialWorkerCollection;
            }
            private set
            {
                _socialWorkerCollection = value;
                OnPropertyChanged("SocialWorkerCollection");
            }
        }

        public SocialWorkersPageViewModel(SocialWorkerService model, IPageDialogService pageDialogService, INavigationService navigationService)
        {
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            _socialWorkerService = model;
        }

        
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            LoadDataAsync();
        }
        private void Navigation(NavigationParameters parameter)
        {
            string navPath = "MainMasterDetailPage/MainNavigationPage/MainPage";
            _navigationService.NavigateAsync(navPath, parameter);
        }
        private async void LoadDataAsync()
        {
            ObservableCollection<SocialWorker> socialWorkers = new ObservableCollection<SocialWorker>();
            try
            {
                var data = await _socialWorkerService.GetAllAsync();
                IsLoading = false;
                foreach (var sw in data)
                    socialWorkers.Add(sw);
                SocialWorkerCollection = socialWorkers;
                Title = "Кількість соціальних працівників: " + SocialWorkerCollection.Count;
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
