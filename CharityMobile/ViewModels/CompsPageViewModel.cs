using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using CharityMobile.Services;
using Prism.Navigation;
using CharityMobile.Models;
using CharityMobile.DAL;
using Prism.Services;

namespace CharityMobile.ViewModels
{
    public class CompsPageViewModel : BindableBase, INavigationAware
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
        private CompanyService _compService;

        public ObservableCollection<Company> _companyCollection;
        public ObservableCollection<Company> CompanyCollection
        {
            get
            {
                return _companyCollection;
            }
            private set
            {
                _companyCollection = value;
                OnPropertyChanged("CompanyCollection");
            }
        }

        public CompsPageViewModel(CompanyService model, INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            _compService = model;
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
            ObservableCollection<Company> companies = new ObservableCollection<Company>();
            try
            {
                var data = await _compService.GetAllAsync();
                IsLoading = false;
                foreach (var comp in data)
                    companies.Add(comp);
                CompanyCollection = companies;
                Title = "Кількість компаній: " + CompanyCollection.Count;
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
