using Application.Commands;
using MediatR;
using Microsoft.Toolkit.Mvvm.Input;

namespace Application.ViewModel
{
    public class SettingsViewModel : CoreViewModel
    {
        public IAsyncRelayCommand ReturnToMenuCommand { get; }

        public SettingsViewModel(
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