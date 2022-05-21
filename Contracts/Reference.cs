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
                Id = new Guid("e6c60ce2-9aa5-4d34-a2ac-ce208ecbbbce"),
                CharacterType = CharacterType.Enemy,
                Name = "Angela Plantajenner",
                Skills = new Dictionary<string, int>
                {
                    { Skills.Provoke, 1 },
                    { Skills.Notice, 2 },
                    { Skills.Empathy, 1 },
                    { Skills.Crafts, 2 },
                    { Skills.Physique, 1 },
                    { Skills.Will, 2 },
                },
                StressTracks = GetDefaultStressTracks(),
                Stunts = "Shipwright: +2 Crafts to repair ship",
                Aspects = new List<string>
                {
                    "Starship Captain",
                    "Only cares about the ship"
                },
                Consequences = new List<Consequence>
                {
                    new Consequence { Level = 3 },
                    new Consequence { Level = 2 },
                    new Consequence { Level = 2 },
                    new Consequence { Level = 1 }
                }
            },
            new CharacterDto
            {
                Id = new Guid("e933ddd1-24e8-4114-97d7-65450e724248"),
                CharacterType = CharacterType.Enemy,
                Name = "Gerry \"Gunner\" Macker",
                Skills = new Dictionary<string, int>
                {
                    { Skills.Shoot, 4 },
                    { Skills.Investigate, 4 },
                    { Skills.Notice, 3 },
                    { Skills.Will, 4 },
                    { Skills.Physique, 1 },
                },
                StressTracks = GetDefaultStressTracks(),
                Stunts = "Doubleshot: Shoot twice in a single turn",
                Aspects = new List<string>
                {
                    "Starship First Mate",
                    "Fastest Gun in space"
                },
                Consequences = new List<Consequence>
                {
                    new Consequence { Level = 2 },
                    new Consequence { Level = 2 },
                    new Consequence { Level = 4 }
                }
            },
            new CharacterDto
            {
                Id = new Guid("1b0e4fbe-38af-4234-bca2-4d8ff6a0a003"),
                CharacterType = CharacterType.Enemy,
                Name = "RoboSentry",
                Skills = new Dictionary<string, int>
                {
                    { Skills.Shoot, 4 },
                    { Skills.Physique, 3 },
                },
                StressTracks = new List<StressTrack>{
                    new StressTrack
                    {
                        Name = "Physical Stress",
                        Skill = Skills.Physique,
                        Stress = new List<Stress>
                        {
                            new Stress( 1, false ),
                            new Stress( 1, false ),
                            new Stress( 1, false ),
                            new Stress( 1, false ),
                            new Stress( 1, false )
                        }
                    },
                },
                Stunts = "Doubleshot: Shoot twice in a single turn",
                Aspects = new List<string>
                {
                    "Robotic Soldier",
                    "Dumb Robot",
                    "Inhuman"
                },
                Consequences = new List<Consequence>
                {
                    new Consequence { Level = 2 }
                }
            },
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
