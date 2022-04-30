namespace FateCoordinator.Model.Characters
{
    public class CharacterStressTrack : UserEntity
    {
        public Guid CharacterId { get; set; }
        public Guid GameSkillId { get; set; }
        public bool IsMarked { get; set; }
        public int Level { get; set; } = 1;
    }
}