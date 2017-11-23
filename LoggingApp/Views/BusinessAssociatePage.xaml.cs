using LoggingApp.ViewModels;
using Windows.UI.Xaml.Controls;

namespace LoggingApp.Views
{
    public sealed partial class BusinessAssociatePage : Page
    {
        public BusinessAssociatePageViewModel ViewModel => DataContext as BusinessAssociatePageViewModel;

        public BusinessAssociatePage()
        {
            InitializeComponent();
        }
    }
}
