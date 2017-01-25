using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using Prism.Navigation;
using CharityMobile.Models;
using CharityMobile.Services;
using Prism.Services;
using CharityMobile.DAL;

namespace CharityMobile.ViewModels
{
    public class OrgsPageViewModel : BindableBase, INavigationAware
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
            set { SetProperty(ref _IsLoading, value, "IsLoading"); }
        }
        private OrganizationService _orgService;

        public ObservableCollection<Organization> _orgCollection;
        public ObservableCollection<Organization> OrgCollection
        {
            get
            {
                return _orgCollection;
            }
            private set
            {
                _orgCollection = value;
                OnPropertyChanged("OrgCollection");
            }
        }
        public OrgsPageViewModel(OrganizationService model, IPageDialogService pageDialogService, INavigationService navigationService)
        {
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            _orgService = model;
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            ObservableCollection<Organization> orgs = new ObservableCollection<Organization>();
            try
            {
                var data = await _orgService.GetAllAsync();
                IsLoading = false;
                foreach (var sw in data)
                    orgs.Add(sw);
                OrgCollection = orgs;
                Title = "Кількість організацій: " + orgs.Count;
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
