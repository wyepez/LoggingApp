using LoggingApp.ViewModels;
using LoggingApp.Views;
using System.Threading.Tasks;
using Template10.Common;
using Template10.Services.NavigationService;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;

namespace LoggingApp
{
    sealed partial class App : BootStrapper
    {
        public App()
        {
            InitializeComponent();
        }

        public override Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            return NavigationService.NavigateAsync(typeof(Views.BusinessAssociatePage));
        }

        public override INavigable ResolveForPage(Page page, NavigationService navigationService)
        {
            switch (page)
            {
                case BusinessAssociatePage p:
                    return ((UnityLocator)Resources["Locator"]).BusinessAssociatePageViewModel;
                default:
                    return base.ResolveForPage(page, navigationService);
            }
        }
    }
}
