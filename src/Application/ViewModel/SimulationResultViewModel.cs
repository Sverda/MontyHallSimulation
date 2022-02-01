using Application.Commands;
using MediatR;
using Microsoft.Toolkit.Mvvm.Input;

namespace Application.ViewModel
{
    public class SimulationResultViewModel : CoreViewModel
    {
        private string winnersWithoutChangedAnswer;
        private string winnersWithChangedAnswer;

        public string WinnersWithoutChangedAnswer
        {
            get => winnersWithoutChangedAnswer;
            set
            {
                winnersWithoutChangedAnswer = value;
                OnPropertyChanged();
            }
        }
        public string WinnersWithChangedAnswer
        {
            get => winnersWithChangedAnswer;
            set
            {
                uiContext.BeginInvoke(() =>
                {
                    winnersWithChangedAnswer = value;
                    OnPropertyChanged();
                });
            }
        }

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
