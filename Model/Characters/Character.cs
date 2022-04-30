using System.ComponentModel.DataAnnotations;

namespace FateCoordinator.Model.Characters
{
    public class Character : UserEntity
    {
        [StringLength(2500)]
        public string? Description { get; set; }

        public int FatePoints { get; set; } = 3;

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(25)]
        public string? Pronouns { get; set; }

        public int Refresh { get; set; } = 3;
    }
}