using Domain.Common;

namespace Domain.ValueObjects
{
    public class SimulationScenarioResultValueObject : ValueObject
    {
        public int WinsWithoutChangedAnswer { get; }
        public int WindWithChangedAnswer { get; }

        public SimulationScenarioResultValueObject(int winsWithoutChangedAnswer, int windWithChangedAnswer)
        {
            WinsWithoutChangedAnswer = winsWithoutChangedAnswer;
            WindWithChangedAnswer = windWithChangedAnswer;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return WinsWithoutChangedAnswer;
            yield return WindWithChangedAnswer;
        }
    }
}