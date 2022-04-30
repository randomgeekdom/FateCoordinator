using System.ComponentModel.DataAnnotations;

namespace FateCoordinator.Model.Characters
{
    public class CharacterAspect : UserEntity
    {
        /// <summary>
        /// High Concept, Trouble, Relationship, Aspect
        /// </summary>
        public string? AspectType { get; set; }

        [StringLength(250)]
        public string? Name { get; set; }
    }
}