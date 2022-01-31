using Domain.Common;

namespace Domain.ValueObjects
{
    public class SimulationScenarioResultValueObject : ValueObject
    {
        public int WinsWithoutChangedAnswer { get; }
        public int WinsWithChangedAnswer { get; }

        public SimulationScenarioResultValueObject(int winsWithoutChangedAnswer, int windWithChangedAnswer)
        {
            WinsWithoutChangedAnswer = winsWithoutChangedAnswer;
            WinsWithChangedAnswer = windWithChangedAnswer;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return WinsWithoutChangedAnswer;
            yield return WinsWithChangedAnswer;
        }
    }
}