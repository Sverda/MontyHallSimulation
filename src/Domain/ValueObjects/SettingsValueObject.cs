using Domain.Common;

namespace Domain.ValueObjects
{
    public class SettingsValueObject : ValueObject
    {
        public string Seed { get; }
        public int Iterations { get; }

        public SettingsValueObject(string seed, int iterations)
        {
            Seed = seed;
            if (iterations % 2 == 1)
            {
                throw new ArgumentException("Iterations need to be an even value");
            }

            Iterations = iterations;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Seed;
            yield return Iterations;
        }
    }
}
