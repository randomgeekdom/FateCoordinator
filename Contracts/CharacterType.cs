using FateCoordinator.Extensions;

namespace FateCoordinator.Contracts
{
    public enum CharacterType
    {
        [CharacterTypeColor("primary")]
        Player,

        [CharacterTypeColor("warning")]
        NPC,

        [CharacterTypeColor("danger")]
        Enemy
    }
}