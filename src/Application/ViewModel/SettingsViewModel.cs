using MediatR;

namespace Application.ViewModel
{
    public class SettingsViewModel : CoreViewModel
    {
        public SettingsViewModel(
            IMediator mediator,
            IViewLocator viewLocator,
            IServiceProvider serviceProvider)
            : base(mediator, viewLocator, serviceProvider)
        {
        }
    }
}