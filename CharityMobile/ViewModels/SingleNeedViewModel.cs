using Prism.Mvvm;
using Prism.Navigation;
using System;

namespace CharityMobile.ViewModels
{
    public class SingleNeedViewModel : BindableBase, INavigationAware
    {
        public SingleNeedViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            //Here will be loaded data by parameter

            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
