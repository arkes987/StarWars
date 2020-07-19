using Microsoft.AspNetCore.Mvc;
using Starwars.Abstraction.Dto.Character;
using Starwars.Abstraction.Dto.Paging;
using Starwars.Abstraction.Interfaces.Logic;
using Starwars.Abstraction.Interfaces.Mappings;
using Starwars.Data.Models.Character;
using System.Linq;
using System.Threading.Tasks;

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

        /// <summary>
        /// Gets character by given id
        /// </summary>
        /// <param name="characterId">Id of character</param>
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

        /// <summary>
        /// Gets all active characters
        /// </summary>
        /// <returns>Array of characters</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet]
        public async Task<ActionResult<CharacterResponseDto[]>> GetAllCharacters()
        {
            var characters = await _charactersLogic.GetAllCharacters();

            return Ok(characters?.Select(_characterMapping.ToCharacterResponseDto).ToArray());
        }

        /// <summary>
        /// Gets paged active characters
        /// </summary>
        /// <param name="page">Number of page to get</param>
        /// <param name="pageSize">Size of page(count of elements in page)</param>
        /// <returns>Array of characters and additional paging info</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("page/{page}/pageSize/{pageSize}")]
        public async Task<ActionResult<PageResponseDto<CharacterResponseDto>>> GetCharactersPaged(int page, int pageSize)
        {
            var charactersPaged = await _charactersLogic.GetCharactersPaged(page, pageSize);

            var responseDto = _pagingMapping.ToPageResponseDto(charactersPaged, _characterMapping.ToCharacterResponseDto);

            return Ok(responseDto);
        }

        /// <summary>
        /// Adds new character
        /// </summary>
        /// <param name="characterDto"></param>
        /// <returns>Newly added character</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPost]
        public async Task<ActionResult<CharacterResponseDto>> AddCharacter(CharacterDto characterDto)
        {
            var characterAdded = await _charactersLogic.AddCharacter(_characterMapping.ToCharacterModel(characterDto));

            return Ok(_characterMapping.ToCharacterResponseDto(characterAdded));
        }

        /// <summary>
        /// Updates character by id with given data in body
        /// </summary>
        /// <param name="characterDto">Character data to update</param>
        /// <param name="characterId">Id of character</param>
        /// <returns>Updated character</returns>
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

        /// <summary>
        /// Soft deletes character(changes status to deleted)
        /// </summary>
        /// <param name="characterId">Id of character</param>
        /// <returns>Deleted character</returns>
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
