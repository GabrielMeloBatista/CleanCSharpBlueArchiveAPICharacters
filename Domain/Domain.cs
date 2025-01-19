using Domain.Entities;

namespace Domain.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string School { get; set; }
        public string? Birthday { get; set; }
        public string PhotoUrl { get; set; }
        public string? Image { get; set; }
        public string ImageSchool { get; set; }
        public string DamageType { get; set; }
    }
}

namespace Domain.Interfaces
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetAllAsync();
        Task<Character?> GetByNameAsync(string name);
        Task<IEnumerable<Character>> GetBySchoolAsync(string school);
        Task<IEnumerable<Character>> GetStudentsAsync();
        Task<Character?> GetRandomAsync();
        Task UpsertAsync(Character character);
    }
}
