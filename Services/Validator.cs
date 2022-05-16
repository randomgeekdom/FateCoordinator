using FateCoordinator.Contracts;

namespace FateCoordinator.Services
{
    public class Validator : IValidator
    {
        public IEnumerable<string> ValidateCharacter(CharacterDto character)
        {
            var validation = new List<string>();

            var aspectCount = character.Aspects.Count(x => !string.IsNullOrWhiteSpace(x));
            var refreshLimit = 6 - aspectCount;
            if (character.Refresh > refreshLimit)
            {
                validation.Add($"Your refresh cannot be greater than {refreshLimit}.");
            }

            if (aspectCount < 2)
            {
                validation.Add("You must have at least 2 aspects: a High-Concept and a Trouble.");
            }

            if (character.FatePoints > character.Refresh)
            {
                validation.Add("Your Fate Points must be fewer than your Refresh.");
            }

            if (string.IsNullOrWhiteSpace(character.Name))
            {
                validation.Add("Your character must have a name.");
            }

            var maxSkillValue = character.Skills.Max(x => x.Value);
            var currentValue = maxSkillValue;

            while (currentValue > 0)
            {
                var lastValueCount = character.Skills.Count(x => x.Value == currentValue);
                currentValue--;
                var thisValueCount = character.Skills.Count(x => x.Value == currentValue);

                if (lastValueCount > thisValueCount)
                {
                    validation.Add($"Cannot have more level {currentValue + 1} skills than level {currentValue} skills");
                }
            }

            return validation;
        }
    }

}
