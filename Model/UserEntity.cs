using System.ComponentModel.DataAnnotations;

namespace FateCoordinator.Model
{
    public abstract class UserEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }
    }
}