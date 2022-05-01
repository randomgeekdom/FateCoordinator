namespace FateCoordinator.Repositories
{
    public class CharacterDto
    {
        public List<string> Aspects { get; set; } = new List<string>();
        public string? Description { get; set; }

        public int FatePoints { get; set; } = 3;
        public string? Name { get; set; }
        public string? Pronouns { get; set; }

        public int Refresh { get; set; } = 3;
    }
}