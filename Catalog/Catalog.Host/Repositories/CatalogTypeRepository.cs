using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Catalog.Host.Models.Requests;

namespace Catalog.Host.Repositories
{
    public class CatalogTypeRepository : ICatalogTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogTypeRepository> _logger;

        public CatalogTypeRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper, ILogger<CatalogTypeRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<GetData<CatalogType>> GetAsync()
        {
            var types = await _dbContext.CatalogTypes.ToListAsync();
            return new GetData<CatalogType>() { Data = types };
        }

        public async Task<int?> Add(string type)
        {
            var newType = new CatalogType() { Type = type };
            var item = await _dbContext.AddAsync(newType);

            await _dbContext.SaveChangesAsync();

            return item.Entity.Id;
        }

        public async Task<int?> Remove(int id)
        {
            var item = await _dbContext.CatalogTypes.SingleAsync(c => c.Id == id);
            _dbContext.CatalogTypes.Remove(item);
            await _dbContext.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int?> Update(CatalogType type)
        {
            var item = _dbContext.CatalogTypes.Update(type);
            await _dbContext.SaveChangesAsync();
            return item.Entity.Id;
        }
    }
}
