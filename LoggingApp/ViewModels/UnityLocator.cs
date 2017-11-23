using LoggingApp.Services;
using Unity;

namespace LoggingApp.ViewModels
{
    public class UnityLocator
    {
        private readonly UnityContainer unityContainer = new UnityContainer();

        public BusinessAssociatePageViewModel BusinessAssociatePageViewModel => unityContainer.Resolve<BusinessAssociatePageViewModel>();

        public UnityLocator()
        {
            unityContainer.RegisterType<IBusinessAssociateService, BusinessAssociateService>();
        }
    }
}
