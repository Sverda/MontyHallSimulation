using Application.Commands;
using MediatR;
using Microsoft.Toolkit.Mvvm.Input;

namespace Application.ViewModel
{
    public class MenuViewModel : CoreViewModel
    {
        public IAsyncRelayCommand SettingsCommand { get; }
        public IAsyncRelayCommand StartSimulationCommand { get; }

        public MenuViewModel(
            IMediator mediator,
            IViewLocator viewLocator,
            IServiceProvider serviceProvider,
            IUIContext uiContext)
            : base(mediator, viewLocator, serviceProvider, uiContext)
        {
            SettingsCommand = new AsyncRelayCommand(ShowSettings);
            StartSimulationCommand = new AsyncRelayCommand(StartSimulation);
        }

        private async Task ShowSettings()
        {
            await mediator.Send(new ShowSettingsCommand());
        }

        private async Task StartSimulation()
        {
            await mediator.Send(new StartSimulationCommand());
        }
    }
}
