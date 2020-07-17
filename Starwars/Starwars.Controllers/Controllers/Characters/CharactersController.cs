using Microsoft.AspNetCore.Mvc;
using Starwars.Abstraction.Interfaces.Logic;

namespace Starwars.Controllers.Controllers.Characters
{
    [ApiController]
    [Route("[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ICharactersLogic _charactersLogic;
        public CharactersController(ICharactersLogic charactersLogic)
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
