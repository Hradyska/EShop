using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Catalog.Host.Models.Responses;
using Catalog.Host.Models.Requests;

namespace Catalog.Host.Repositories
{
    public class CatalogBrandRepository : ICatalogBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogBrandRepository> _logger;

        public CatalogBrandRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper, ILogger<CatalogBrandRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<GetData<CatalogBrand>> GetAsync()
        {
            var brands = await _dbContext.CatalogBrands.ToListAsync();
            return new GetData<CatalogBrand>() { Data = brands };
        }

        public async Task<int?> Add(string brand)
        {
            var newBrand = new CatalogBrand() { Brand = brand };
            var result = await _dbContext.AddAsync(newBrand);
            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<int?> Remove(int id)
        {
            var item = await _dbContext.CatalogBrands.SingleAsync(c => c.Id == id);
            _dbContext.CatalogBrands.Remove(item);
            await _dbContext.SaveChangesAsync();
            return item.Id;
        }

        public async Task<int?> Update(CatalogBrand brand)
        {
            var item = _dbContext.CatalogBrands.Update(brand);
            await _dbContext.SaveChangesAsync();
            return item.Entity.Id;
        }
    }
}
