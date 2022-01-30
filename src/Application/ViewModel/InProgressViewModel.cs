using Application.Commands;
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
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            PrepareSimulation();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private async Task PrepareSimulation()
        {
            await mediator.Send(new ShowSimulationResultCommand());
        }
    }
}
