using Application.Commands;
using Application.ViewModel;
using MediatR;

namespace Application.Handlers
{
    public class StartSimulationCommandHandler : IRequestHandler<StartSimulationCommand, Unit>
    {
        private readonly MainViewModel mainViewModel;

        public StartSimulationCommandHandler(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public Task<Unit> Handle(StartSimulationCommand request, CancellationToken cancellationToken)
        {
            mainViewModel.ChangeContentToInProgress();
            return Task.FromResult(Unit.Task.Result);
        }
    }
}
