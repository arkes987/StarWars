using Starwars.Abstraction.Dto.Character;
using Starwars.Data.Models.Character;

namespace Starwars.Abstraction.Interfaces.Mappings
{
    public interface ICharacterMapping
    {
        CharacterResponseDto ToCharacterResponseDto(CharacterModel characterModel);

        CharacterModel ToCharacterModel(CharacterDto characterDto);
    }
}
