using Application.Commands;
using Application.ViewModel;
using Domain.Aggregates;
using Domain.ValueObjects;
using MediatR;

namespace Application.Handlers
{
    public class ShowSimulationResultCommandHandler : IRequestHandler<ShowSimulationResultCommand, Unit>
    {
        private readonly Random random;
        private readonly MainViewModel mainViewModel;
        private readonly SimulationResultViewModel simulationResultViewModel;

        public ShowSimulationResultCommandHandler(
            Random random,
            MainViewModel mainViewModel,
            SimulationResultViewModel simulationResultViewModel)
        {
            this.random = random;
            this.mainViewModel = mainViewModel;
            this.simulationResultViewModel = simulationResultViewModel;
        }

        public async Task<Unit> Handle(ShowSimulationResultCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(1000, cancellationToken);
            var simulation = new SimulationScenario(0, new SettingsValueObject("", 100));
            var result = await simulation.Run(random, cancellationToken);
            simulationResultViewModel.WinnersWithoutChangedAnswer = result.WinsWithoutChangedAnswer;
            simulationResultViewModel.WinnersWithChangedAnswer = result.WinsWithChangedAnswer;
            mainViewModel.ChangeContentToSimulationResult(simulationResultViewModel);
            return Unit.Value;
        }
    }
}
