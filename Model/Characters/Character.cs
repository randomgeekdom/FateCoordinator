using System.ComponentModel.DataAnnotations;

namespace FateCoordinator.Model.Characters
{
    public class Character : UserEntity
    {
        public string Data { get; set; } = string.Empty;
    }
}