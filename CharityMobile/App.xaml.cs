using CharityMobile.Views;
using Prism.Unity;

namespace CharityMobile
{
    public partial class App : PrismApplication
    {
        public App()
        {
            InitializeComponent();
        }
        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("MainMasterDetailPage/MainNavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainMasterDetailPage>("MainMasterDetailPage");
            Container.RegisterTypeForNavigation<MainNavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<NeedsPage>();
            Container.RegisterTypeForNavigation<SocialWorkersPage>();
            Container.RegisterTypeForNavigation<SingleNeed>();
            Container.RegisterTypeForNavigation<OrgsPage>();
            Container.RegisterTypeForNavigation<CompsPage>();
            Container.RegisterTypeForNavigation<NeedPage>();
        }
    }
}

