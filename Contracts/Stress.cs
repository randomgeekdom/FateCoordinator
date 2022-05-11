namespace FateCoordinator.Contracts
{
    public class Stress
    {
        public Stress() : this(1, false)
        {
        }
        public Stress(int level, bool value)
        {
            Level = level;
            Value = value;
        }

        public int Level { get; set; }
        public bool Value { get; set; }
    }
}