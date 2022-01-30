using Application.Commands;
using MediatR;
using Microsoft.Toolkit.Mvvm.Input;

namespace Application.ViewModel
{
    public class SimulationResultViewModel : CoreViewModel
    {
        public IAsyncRelayCommand ReturnToMenuCommand { get; }

        public SimulationResultViewModel(
            IMediator mediator,
            IViewLocator viewLocator,
            IServiceProvider serviceProvider,
            IUIContext uiContext)
            : base(mediator, viewLocator, serviceProvider, uiContext)
        {
            ReturnToMenuCommand = new AsyncRelayCommand(ReturnToMenu);
        }

        private async Task ReturnToMenu()
        {
            await mediator.Send(new ReturnToMenuCommand());
        }
    }
}
