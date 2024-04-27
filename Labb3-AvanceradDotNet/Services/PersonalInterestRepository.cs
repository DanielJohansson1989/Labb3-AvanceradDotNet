using Labb3_AvanceradDotNet.Data;
using Labb3Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_AvanceradDotNet.Services
{
    public class PersonalInterestRepository : ILabb3<PersonalInterest>
    {
        private Labb3DbContext _dbContext;
        public PersonalInterestRepository(Labb3DbContext dbContext)
        {
            _dbContext = dbContext;   
        }
        public async Task<PersonalInterest> Add(PersonalInterest newEntity)
        {
            var result = await _dbContext.PersonalInterests.AddAsync(newEntity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<PersonalInterest> Delete(int id)
        {
            var result = await _dbContext.PersonalInterests.FirstOrDefaultAsync(p => p.PersonalInterestId ==  id);
            if (result != null)
            {
                _dbContext.PersonalInterests.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<PersonalInterest>> GetAll()
        {
            return await _dbContext.PersonalInterests.Include(p => p.Person).Include(p => p.Interest).ToListAsync();
        }

        public async Task<PersonalInterest> GetById(int id)
        {
            return await _dbContext.PersonalInterests.Include(p => p.Person).Include(p => p.Interest).FirstOrDefaultAsync(p => p.PersonalInterestId == id);
        }

        public async Task<PersonalInterest> Update(PersonalInterest entity)
        {
            var result = await _dbContext.PersonalInterests.FirstOrDefaultAsync(p => p.PersonalInterestId == entity.PersonalInterestId);
            if (result != null)
            {
                result.PersonId = entity.PersonId;
                result.InterestId = entity.InterestId;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
