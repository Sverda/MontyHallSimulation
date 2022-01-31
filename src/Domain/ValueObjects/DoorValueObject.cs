using Domain.Common;

namespace Domain.ValueObjects
{
    public abstract class DoorValueObject : ValueObject
    {
        public int Index { get; }

        protected DoorValueObject(int index)
        {
            Index = index;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return GetType().Name;
            yield return Index;
        }
    }
}
