using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class SimulationCase : Entity<int>
    {
        private readonly DoorValueObject[] doors = new DoorValueObject[3];
        private readonly Random random;
        private int answerDoorIndex;
        private int revealdEmptyDoorIndex;

        public bool IsWinner => doors[answerDoorIndex] is PrizeDoorValueObject;
        public bool IsAnswerChanged { get; private set; } = false;

        public SimulationCase(int id, Random random) : base(id)
        {
            this.random = random;
        }

        public void RandomDoors()
        {
            var prizeDoorIndex = random.Next(0, doors.Length);
            doors[prizeDoorIndex] = new PrizeDoorValueObject(prizeDoorIndex);
            var notPrizedDoorIndices = Enumerable
                .Range(0, doors.Length)
                .Where(x => x != prizeDoorIndex);
            foreach (var index in notPrizedDoorIndices)
            {
                doors[index] = new EmptyDoorValueObject(index);
            }
        }

        public void RandomAnswer()
        {
            answerDoorIndex = random.Next(0, doors.Length);
        }

        public void RevealEmptyDoor()
        {
            var emptyDoors = doors.Where(d => d is EmptyDoorValueObject && d.Index != answerDoorIndex).ToArray();
            var doorToReveal = emptyDoors[random.Next(0, emptyDoors.Length)];
            revealdEmptyDoorIndex = doorToReveal.Index;
        }

        public void ChangeAnswer()
        {
            var index = Enumerable.Range(0, doors.Length)
                .Single(d => d != answerDoorIndex && d != revealdEmptyDoorIndex);
            answerDoorIndex = index;
            IsAnswerChanged = true;
        }
    }
}
