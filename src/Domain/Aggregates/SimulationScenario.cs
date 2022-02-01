using Domain.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Aggregates
{
    public class SimulationScenario : Entity<int>, IAggregateRoot
    {
        public Settings Settings { get; }

        public SimulationScenario(int id, Settings settings) : base(id)
        {
            Settings = settings;
        }

        public async Task<SimulationScenarioResultValueObject> Run(Random random, CancellationToken cancellationToken)
        {
            _ = random ?? throw new ArgumentNullException(nameof(random));
            var winnersWithoutChangin = await SimulationWinnersWithoutChangingAnswer(random, cancellationToken);
            var winnersWithChangin = await SimulationWinnersWithChangingAnswer(random, cancellationToken);
            return new SimulationScenarioResultValueObject(winnersWithoutChangin, winnersWithChangin);
        }

        private async Task<int> SimulationWinnersWithoutChangingAnswer(Random random, CancellationToken cancellationToken)
        {
            IEnumerable<Task<int>> caseTasks =
                Enumerable.Range(0, Settings.Iterations / 2)
                    .Select(_ => Task.Run(
                        () => CaseWithoutChangingAnswer(random).IsWinner ? 1 : 0,
                        cancellationToken));
            int[] result = await Task.WhenAll(caseTasks);
            return result.Sum();
        }

        private async Task<int> SimulationWinnersWithChangingAnswer(Random random, CancellationToken cancellationToken)
        {
            IEnumerable<Task<int>> caseTasks =
                Enumerable.Range(0, Settings.Iterations / 2)
                    .Select(_ => Task.Run(
                        () => CaseWithChangingAnswer(random).IsWinner ? 1 : 0,
                        cancellationToken));
            int[] result = await Task.WhenAll(caseTasks);
            return result.Sum();
        }

        private SimulationCase CaseWithoutChangingAnswer(Random random)
        {
            var simCase = new SimulationCase(Id, random);
            simCase.RandomDoors();
            simCase.RandomAnswer();
            return simCase;
        }

        private SimulationCase CaseWithChangingAnswer(Random random)
        {
            var simCase = new SimulationCase(Id, random);
            simCase.RandomDoors();
            simCase.RandomAnswer();
            simCase.RevealEmptyDoor();
            simCase.ChangeAnswer();
            return simCase;
        }
    }
}
