using Application.Commands;
using Application.Repositories;
using Application.ViewModel;
using Domain.Aggregates;
using Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class ShowSimulationResultCommandHandler : IRequestHandler<ShowSimulationResultCommand, Unit>
    {
        private readonly Random random;
        private readonly MainViewModel mainViewModel;
        private readonly SimulationResultViewModel simulationResultViewModel;
        private readonly IRepository<Settings, int> settingsRepository;

        public ShowSimulationResultCommandHandler(
            Random random,
            MainViewModel mainViewModel,
            SimulationResultViewModel simulationResultViewModel,
            IRepository<Settings, int> settingsRepository)
        {
            this.random = random;
            this.mainViewModel = mainViewModel;
            this.simulationResultViewModel = simulationResultViewModel;
            this.settingsRepository = settingsRepository;
        }

        public async Task<Unit> Handle(ShowSimulationResultCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(1000, cancellationToken);
            var simulation = new SimulationScenario(0, settingsRepository.GetById(0));
            var result = await simulation.Run(random, cancellationToken);
            simulationResultViewModel.WinnersWithoutChangedAnswer = result.WinsWithoutChangedAnswer;
            simulationResultViewModel.WinnersWithChangedAnswer = result.WinsWithChangedAnswer;
            mainViewModel.ChangeContentToSimulationResult(simulationResultViewModel);
            return Unit.Value;
        }
    }
}
