using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Starwars.Abstraction.Dto.Character;
using Starwars.Abstraction.Dto.Paging;
using Starwars.Abstraction.Interfaces.Logic;
using Starwars.Abstraction.Interfaces.Mappings;
using Starwars.Data.Models.Character;

namespace Starwars.Controllers.Controllers.Character
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterLogic _charactersLogic;
        private readonly ICharacterMapping _characterMapping;
        private readonly IPagingMapping<CharacterResponseDto, CharacterModel> _pagingMapping;
        public CharacterController(ICharacterLogic charactersLogic, ICharacterMapping characterMapping, IPagingMapping<CharacterResponseDto, CharacterModel> pagingMapping)
        {
            _charactersLogic = charactersLogic;
            _characterMapping = characterMapping;
            _pagingMapping = pagingMapping;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{characterId}")]
        public async Task<ActionResult<CharacterResponseDto>> GetCharacter(long characterId)
        {
            var character = await _charactersLogic.GetById(characterId);

            if (character == null)
                return NotFound();

            return Ok(_characterMapping.ToCharacterResponseDto(character));
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet]
        public async Task<ActionResult<CharacterResponseDto[]>> GetAllCharacters()
        {
            var characters = await _charactersLogic.GetAllCharacters();

            return Ok(characters?.Select(_characterMapping.ToCharacterResponseDto).ToArray());
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("page/{page}/pageSize/{pageSize}")]
        public async Task<ActionResult<PageResponseDto<CharacterResponseDto>>> GetCharactersPaged(int page, int pageSize)
        {
            var charactersPaged = await _charactersLogic.GetCharactersPaged(page, pageSize);

            var responseDto = _pagingMapping.ToPageResponseDto(charactersPaged, _characterMapping.ToCharacterResponseDto);

            return Ok(responseDto);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPost]
        public async Task<ActionResult<CharacterResponseDto>> AddCharacter(CharacterDto characterDto)
        {
            var characterAdded = await _charactersLogic.AddCharacter(_characterMapping.ToCharacterModel(characterDto));

            return Ok(_characterMapping.ToCharacterResponseDto(characterAdded));
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{characterId}")]
        public async Task<ActionResult<CharacterResponseDto>> UpdateCharacter(CharacterDto characterDto, long characterId)
        {
            var characterModel = _characterMapping.ToCharacterModel(characterDto);

            _characterMapping.PopulateIdOnModel(characterId, characterModel);

            var updatedCharacter = await _charactersLogic.UpdateCharacter(characterModel);

            if (updatedCharacter == null)
                return NotFound();

            return Ok(_characterMapping.ToCharacterResponseDto(updatedCharacter));
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("{characterId}")]
        public async Task<ActionResult<CharacterResponseDto>> DeleteCharacter(long characterId)
        {
            var deletedCharacter = await _charactersLogic.SoftDeleteCharacter(characterId);

            if (deletedCharacter == null)
                return NotFound();

            return Ok(_characterMapping.ToCharacterResponseDto(deletedCharacter));
        }
    }
}
