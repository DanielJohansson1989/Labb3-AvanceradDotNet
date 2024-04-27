using Labb3_AvanceradDotNet.Data;
using Labb3Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_AvanceradDotNet.Services
{
    
    public class InterestRepository : ILabb3<Interest>
    {
        private Labb3DbContext _dbContext;
        public InterestRepository(Labb3DbContext dbContext)
        {
            _dbContext = dbContext;   
        }
        public async Task<Interest> Add(Interest newEntity)
        {
            var result = await _dbContext.Interests.AddAsync(newEntity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Interest> Delete(int id)
        {
            var result = await _dbContext.Interests.FirstOrDefaultAsync(i => i.InterestId == id);
            if (result != null)
            {
                _dbContext.Interests.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _dbContext.Interests.ToListAsync();
        }

        public async Task<Interest> GetById(int id)
        {
            return await _dbContext.Interests.FirstOrDefaultAsync(i => i.InterestId == id);
        }

        public async Task<Interest> Update(Interest entity)
        {
            var result = await _dbContext.Interests.FirstOrDefaultAsync(i => i.InterestId == entity.InterestId);
            if (result != null)
            {
                result.Title = entity.Title;
                result.Description = entity.Description;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
