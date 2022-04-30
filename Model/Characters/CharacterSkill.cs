using System.ComponentModel.DataAnnotations;

namespace FateCoordinator.Model.Characters
{
    public class CharacterSkill : UserEntity
    {
        public Guid CharacterId { get; set; }

        public Guid GameSkillId { get; set; }

        public int Level { get; set; } = 0;
    }
}