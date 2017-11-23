using LoggingApp.Models;
using LoggingApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Utils;
using Windows.UI.Xaml.Navigation;

namespace LoggingApp.ViewModels
{
    public class BusinessAssociatePageViewModel
        : ViewModelBase
    {
        private IBusinessAssociateService businessAssociateService;

        private BusinessAssociate selectedBusinessAssociate;
        public BusinessAssociate SelectedBusinessAssociate
        {
            get { return selectedBusinessAssociate; }
            set { Set(ref selectedBusinessAssociate, value); }
        }

        public ObservableCollection<BusinessAssociate> BusinessAssociates { get; set; } = new ObservableCollection<BusinessAssociate>();

        public BusinessAssociatePageViewModel(IBusinessAssociateService businessAssociateService)
        {
            this.businessAssociateService = businessAssociateService;
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var response = await businessAssociateService.GetNextPageAsync();
            if (response.IsSuccessful)
            {
                BusinessAssociates.AddRange(response.Result.Items);
            }
            else
            {
                // write logs
            }
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

    }
}
