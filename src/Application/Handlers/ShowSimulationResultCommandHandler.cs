using Application.Commands;
using Application.ViewModel;
using MediatR;

namespace Application.Handlers
{
    public class ShowSimulationResultCommandHandler : IRequestHandler<ShowSimulationResultCommand, Unit>
    {
        private readonly MainViewModel mainViewModel;

        public ShowSimulationResultCommandHandler(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public async Task<Unit> Handle(ShowSimulationResultCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(5000, cancellationToken);
            mainViewModel.ChangeContentToSimulationResult();
            return Unit.Value;
        }
    }
}
