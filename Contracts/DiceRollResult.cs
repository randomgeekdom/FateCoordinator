namespace FateCoordinator.Contracts
{
    public class DiceRollResult
    {
        public DieValue FirstResult { get; set; }
        public DieValue FourthResult { get; set; }
        public int Result { get; set; }
        public DieValue SecondResult { get; set; }
        public DieValue ThirdResult { get; set; }
    }
}
