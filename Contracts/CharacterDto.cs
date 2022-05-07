using System.ComponentModel;

namespace FateCoordinator.Contracts
{
    public class CharacterDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Pronouns { get; set; } = string.Empty;
        public int Refresh { get; set; } = 3;
        public int FatePoints { get; set; } = 3;

        public List<string> Aspects { get; set; } = new List<string>();

        public Dictionary<string, int> Skills { get; set; } = new Dictionary<string, int>();

        public string Extras { get; set; } = string.Empty;
        public string Stunts { get; set; } = String.Empty;

        public List<StressTrack> StressTracks { get; set; } = new List<StressTrack>();

        public List<Consequence> Consequences { get; set; } = new List<Consequence>();

        public CharacterType CharacterType { get; set; } = CharacterType.Player;
    }
}