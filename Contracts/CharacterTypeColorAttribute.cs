namespace FateCoordinator.Extensions
{
    public class CharacterTypeColorAttribute: Attribute
    {
        public CharacterTypeColorAttribute(string bootstrapColor)
        {
            this.BootstrapColor = bootstrapColor;
        }

        public string BootstrapColor { get; }

        public override string ToString()
        {
            return this.BootstrapColor;
        }
    }
}
