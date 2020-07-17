using Starwars.Abstraction.Dto.Character;
using Starwars.Abstraction.Interfaces.Mappings;
using Starwars.Data.Models.Character;

namespace Starwars.Controllers.Mappings.Character
{
    public class CharacterMapping : ICharacterMapping
    {
        public CharacterResponseDto ToCharacterResponseDto(CharacterModel characterModel)
        {
            return new CharacterResponseDto
            {
                Name = characterModel.Name,
                Planet = characterModel.Planet
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
