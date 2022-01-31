using Application.Commands;
using MediatR;
using Microsoft.Toolkit.Mvvm.Input;

namespace Application.ViewModel
{
    public class SimulationResultViewModel : CoreViewModel
    {
        private int winnersWithoutChangedAnswer;
        private int winnersWithChangedAnswer;

        public IAsyncRelayCommand ReturnToMenuCommand { get; }
        public int WinnersWithoutChangedAnswer
        {
            get => winnersWithoutChangedAnswer;
            set
            {
                winnersWithoutChangedAnswer = value;
                OnPropertyChanged();
            }
        }
        public int WinnersWithChangedAnswer
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
