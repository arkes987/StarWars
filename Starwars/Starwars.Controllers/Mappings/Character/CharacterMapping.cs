using Starwars.Abstraction.Dto.Character;
using Starwars.Abstraction.Interfaces.Mappings;
using Starwars.Data.Models.Character;

namespace Starwars.Controllers.Mappings.Character
{
    public class CharacterMapping : ICharacterMapping
    {
        public CharacterResponseDto ToCharacterResponseDto(CharacterModel characterModel)
        {
            throw new System.NotImplementedException();
        }

        public CharacterModel ToCharacterModel(CharacterDto characterDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
