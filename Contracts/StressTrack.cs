namespace FateCoordinator.Contracts
{
    public class StressTrack
    {
        public string Skill { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Dictionary<int, bool> Stress { get; set; } = new Dictionary<int, bool>();
    }
}