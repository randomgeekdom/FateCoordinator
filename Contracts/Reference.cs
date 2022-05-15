using FateCoordinator.Contracts;
using System.Reflection;

namespace FateCoordinator.Services
{
    public static class Reference
    {
        public static IEnumerable<CharacterDto> Bestiary => bestiary;
        private static IEnumerable<CharacterDto> bestiary => new List<CharacterDto>{
            new CharacterDto
            {
                Id = new Guid("e933ddd1-24e8-4114-97d7-65450e724248"),
                CharacterType = CharacterType.Enemy,
                Name = "Gerry \"Gunner\" Macker",
                Skills = new Dictionary<string, int>
                {
                    { Skills.Shoot, 4 },
                    { Skills.Investigate, 4 },
                    { Skills.Notice, 4 },
                    { Skills.Will, 3 },
                    { Skills.Physique, 1 },
                },
                StressTracks = GetDefaultStressTracks(),
                Stunts = "Doubleshot: Shoot twice in a single turn",
                Aspects = new List<string>
                {
                    "Starship First Mate",
                    "Fastest Gun in space"
                }
            }
        };

        public static List<Consequence> GetDefaultConsequences() => new List<Consequence>
                {
                    new Consequence{
                        Condition = string.Empty,
                        Level = 2
                    },

                    new Consequence{
                        Condition = string.Empty,
                        Level = 4
                    },

                    new Consequence{
                        Condition = string.Empty,
                        Level = 6
                    }
                };

        public static IOrderedEnumerable<string> GetDefaultSkills()
        {
            var list = typeof(Skills).GetFields(BindingFlags.Public | BindingFlags.Static).Select(x => x.GetValue(null).ToString()).OrderBy(x => x);
            return list;
        }
        public static List<StressTrack> GetDefaultStressTracks() => new List<StressTrack>
                {
                    new StressTrack
                    {
                        Name = "Physical Stress",
                        Skill = Skills.Physique,
                        Stress = new List<Stress>
                        {
                            new Stress( 1, false ),
                            new Stress( 2, false )
                        }
                    },

                    new StressTrack
                    {
                        Name = "Mental Stress",
                        Skill = Skills.Will,
                        Stress = new List<Stress>
                        {
                            new Stress( 1, false ),
                            new Stress( 2, false )
                        }
                    }
                };
    }
}
