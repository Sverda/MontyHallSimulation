using Domain.Common;

namespace Domain.Entities
{
    public class Settings : Entity<int>
    {
        private int iterations;

        public string Seed { get; set; }
        public int Iterations
        {
            get => iterations;
            set
            {
                ValidateSeed(value);
                iterations = value;
            }
        }

        public Settings(int id, string seed, int iterations) : base(id)
        {
            Seed = seed;
            Iterations = iterations;
        }

        private static void ValidateSeed(int iterations)
        {
            if (iterations % 2 == 1)
            {
                throw new ArgumentException("Iterations need to be an even value");
            }
        }
    }
}
