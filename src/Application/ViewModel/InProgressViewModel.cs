using Application.Commands;
using MediatR;

namespace Application.ViewModel
{
    public class InProgressViewModel : CoreViewModel
    {
        private string errorMessage;
        private bool showErrorMessage;

        public bool ShowErrorMessage
        {
            get => showErrorMessage;
            set
            {
                showErrorMessage = value;
                OnPropertyChanged();
            }
        }
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

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
            try
            {
                await mediator.Send(new ShowSimulationResultCommand());
            }
            catch (Exception e)
            {
                ShowErrorMessage = true;
                ErrorMessage = e.Message;
                throw;
            }
        }
    }
}
