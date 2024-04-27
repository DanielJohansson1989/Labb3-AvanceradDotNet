using Labb3_AvanceradDotNet.Data;
using Labb3Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3_AvanceradDotNet.Services
{
    public class LinkRepository : ILabb3<Link>
    {
        private Labb3DbContext _dbContext;
        public LinkRepository(Labb3DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Link> Add(Link newEntity)
        {
            var result = await _dbContext.Links.AddAsync(newEntity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Link> Delete(int id)
        {
            var result = await _dbContext.Links.FirstOrDefaultAsync(l => l.LinkId == id);
            if (result != null)
            {
                _dbContext.Links.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _dbContext.Links.Include(l => l.PersonalInterest).ThenInclude(p => p.Person)
                .Include(p => p.PersonalInterest).ThenInclude(p => p.Interest).ToListAsync();
        }

        public async Task<Link> GetById(int id)
        {
            return await _dbContext.Links.Include(l => l.PersonalInterest).ThenInclude(p => p.Person)
                .Include(p => p.PersonalInterest).ThenInclude(p => p.Interest).FirstOrDefaultAsync(l => l.LinkId == id);
        }

        public async Task<Link> Update(Link entity)
        {
            var result = await _dbContext.Links.FirstOrDefaultAsync(l => l.LinkId == entity.LinkId);
            if (result != null)
            {
                result.URL = entity.URL;
                result.PersonalInterestId = entity.PersonalInterestId;
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
