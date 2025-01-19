using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CharacterService
    {
        private readonly ICharacterRepository _repository;

        public CharacterService(ICharacterRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Character?> GetCharacterByName(string name)
        {
            return await _repository.GetByNameAsync(name);
        }

        public async Task<IEnumerable<Character>> GetCharactersBySchool(string school)
        {
            return await _repository.GetBySchoolAsync(school);
        }

        public async Task<IEnumerable<Character>> GetStudents()
        {
            return await _repository.GetStudentsAsync();
        }

        public async Task<Character?> GetRandomCharacter()
        {
            return await _repository.GetRandomAsync();
        }

        public async Task UpsertCharacter(Character character)
        {
            await _repository.UpsertAsync(character);
        }
    }
}