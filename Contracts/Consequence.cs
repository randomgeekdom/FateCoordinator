namespace FateCoordinator.Contracts
{
    public class Consequence
    {
        public string Skill { get; set; } = string.Empty;
        public int Level { get; set; }
        public bool IsChecked { get; set; }
        public string Condition { get; set; } = string.Empty;
    }
}