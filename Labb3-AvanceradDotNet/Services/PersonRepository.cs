using Labb3_AvanceradDotNet.Data;
using Labb3Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_AvanceradDotNet.Services
{
    public class PersonRepository : ILabb3<Person>
    {
        private Labb3DbContext _dbContext;
        public PersonRepository(Labb3DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Person> Add(Person newEntity)
        {
            var result = await _dbContext.Persons.AddAsync(newEntity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Person> Delete(int id)
        {
            var result= await _dbContext.Persons.FirstOrDefaultAsync(p => p.PersonId == id);
            if (result != null)
            {
                _dbContext.Persons.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _dbContext.Persons.Include(p => p.Interest).ThenInclude(i => i.Link).ToListAsync();
        }

        public async Task<Person> GetById(int id)
        {
            return await _dbContext.Persons.Include(p => p.Interest).ThenInclude(i => i.Link).FirstOrDefaultAsync(p => p.PersonId == id);
        }

        public async Task<Person> Update(Person entity)
        {
            var result = await _dbContext.Persons.FirstOrDefaultAsync(p => p.PersonId == entity.PersonId);
            if (result != null)
            {
                result.FirstName = entity.FirstName;
                result.LastName = entity.LastName;
                result.Phone = entity.Phone;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
