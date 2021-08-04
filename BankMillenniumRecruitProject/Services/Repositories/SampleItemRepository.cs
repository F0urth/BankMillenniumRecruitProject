using System;
using System.Linq;
using System.Threading.Tasks;
using BankMillenniumRecruitProject.Data;
using BankMillenniumRecruitProject.Extensions;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace BankMillenniumRecruitProject.Services.Repositories
{
    public class SampleItemRepository : ISampleItemRepository
    {
        private readonly MillenniumDbContext _dbContext;

        public SampleItemRepository(MillenniumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SampleItem> Add(SampleItem entity)
        {
            entity.CheckIsNotNull();
            _dbContext.SampleItems.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Remove(long id)
        {
            SampleItem sampleItem = new() { Id = id };

            _dbContext.SampleItems.Attach(sampleItem);
            _dbContext.SampleItems.Remove(sampleItem);

            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(SampleItem entity)
        {
            entity.CheckIsNotNull();
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SampleItem> Get(long id)
        {
            return await _dbContext.SampleItems.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> IsExists(long id)
        {
            return await _dbContext.SampleItems
                .AnyAsync(e => e.Id == id);
        }

        public IQueryable<SampleItem> GetAll()
        {
            return _dbContext.SampleItems;
        }
    }
}