using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApiHost.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly CharacterService _characterService;

        public CharactersController(CharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var characters = await _characterService.GetAllCharacters();
            return Ok(characters);
        }

        [HttpGet("by-name")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var character = await _characterService.GetCharacterByName(name);
            return character != null ? Ok(character) : NotFound();
        }

        [HttpGet("by-school")]
        public async Task<IActionResult> GetBySchool([FromQuery] string school)
        {
            var characters = await _characterService.GetCharactersBySchool(school);
            return Ok(characters);
        }

        [HttpGet("students")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _characterService.GetStudents();
            return Ok(students);
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandom()
        {
            var character = await _characterService.GetRandomCharacter();
            return character != null ? Ok(character) : NotFound();
        }
    }
}
