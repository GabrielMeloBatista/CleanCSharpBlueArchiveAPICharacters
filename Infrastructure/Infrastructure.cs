using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly AppDbContext _dbContext;

        public CharacterRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Character>> GetAllAsync()
        {
            return await _dbContext.Characters.ToListAsync();
        }

        public async Task<Character?> GetByNameAsync(string name)
        {
            return await _dbContext.Characters.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<IEnumerable<Character>> GetBySchoolAsync(string school)
        {
            return await _dbContext.Characters.Where(c => c.School == school).ToListAsync();
        }

        public async Task<IEnumerable<Character>> GetStudentsAsync()
        {
            return await _dbContext.Characters.Where(c => c.School != null).Take(4).ToListAsync();
        }

        public async Task<Character?> GetRandomAsync()
        {
            return await _dbContext.Characters.OrderBy(r => Guid.NewGuid()).FirstOrDefaultAsync();
        }

        public async Task UpsertAsync(Character character)
        {
            var existingCharacter = await _dbContext.Characters.FindAsync(character.Id);
            if (existingCharacter == null)
            {
                await _dbContext.Characters.AddAsync(character);
            }
            else
            {
                _dbContext.Entry(existingCharacter).CurrentValues.SetValues(character);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}