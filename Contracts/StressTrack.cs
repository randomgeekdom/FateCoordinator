namespace FateCoordinator.Contracts
{
    public class StressTrack
    {
        public string Skill { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<Stress> Stress { get; set; } = new List<Stress>();
    }
}