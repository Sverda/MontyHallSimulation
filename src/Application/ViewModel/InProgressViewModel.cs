using MediatR;

namespace Application.ViewModel
{
    public class InProgressViewModel : CoreViewModel
    {
        public InProgressViewModel(
            IMediator mediator,
            IViewLocator viewLocator,
            IServiceProvider serviceProvider,
            IUIContext uiContext)
            : base(mediator, viewLocator, serviceProvider, uiContext)
        {
        }
    }
}
