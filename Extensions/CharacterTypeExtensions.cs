using FateCoordinator.Contracts;

namespace FateCoordinator.Extensions
{
    public static class CharacterTypeExtensions
    {
        public static string GetBoostrapColor(this CharacterType characterType)
        {
            var enumType = characterType.GetType();
            var name = Enum.GetName(enumType, characterType);
            return enumType.GetField(name).GetCustomAttributes(false).OfType<CharacterTypeColorAttribute>().SingleOrDefault().BootstrapColor;
        }
    }
}
