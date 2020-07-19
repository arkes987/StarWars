using Starwars.Abstraction.Dto.Character;
using Starwars.Abstraction.Interfaces.Mappings;
using Starwars.Data.Models.Character;
using System.Linq;

namespace Starwars.Controllers.Mappings.Character
{
    public class CharacterMapping : ICharacterMapping
    {
        public CharacterResponseDto ToCharacterResponseDto(CharacterModel characterModel)
        {
            return new CharacterResponseDto
            {
                Name = characterModel.Name,
                Planet = characterModel.Planet,
                Episodes = characterModel.Episodes?.Select(episode => episode.Episode?.Name).ToArray(),
                Friends = characterModel.Friends?.Select(friend => friend.Character?.Name).ToArray()
            };
        }

        public CharacterModel ToCharacterModel(CharacterDto characterDto)
        {
            return new CharacterModel
            {
                Name = characterDto.Name,
                Planet = characterDto.Planet
            };
        }

        public void PopulateIdOnModel(long characterId, CharacterModel characterModel)
        {
            characterModel.Id = characterId;
        }
    }
}
