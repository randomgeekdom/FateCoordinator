namespace FateCoordinator.Model.Characters
{
    public class CharacterConsequence : UserEntity
    {
        public Guid CharacterId { get; set; }
        public string? Consequence { get; set; }
        public int Level { get; set; }
    }
}