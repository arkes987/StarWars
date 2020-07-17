using Microsoft.AspNetCore.Mvc;
using Starwars.Abstraction.Interfaces.Logic;

namespace Starwars.Controllers.Controllers.Character
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterLogic _charactersLogic;
        public CharacterController(ICharacterLogic charactersLogic)
        {
            _charactersLogic = charactersLogic;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public void GetCharacter(long id)
        {
            
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPost]
        public void AddCharacter(long id)
        {

        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpPut("{id}")]
        public void UpdateCharacter(long id)
        {

        }

        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public void DeleteCharacter(long id)
        {

        }
    }
}
