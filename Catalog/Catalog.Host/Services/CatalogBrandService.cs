using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
    {
        private readonly ICatalogBrandRepository _catalogBrandRepository;
        private readonly IMapper _mapper;

        public CatalogBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogBrandRepository catalogBrandRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _catalogBrandRepository = catalogBrandRepository;
            _mapper = mapper;
        }

        public Task<int?> Add(string brand)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.Add(brand));
        }

        public Task<int?> Remove(int id)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.Remove(id));
        }

        public Task<int?> Update(CatalogBrandDto brand)
        {
            CatalogBrand brandRepo = new CatalogBrand()
            {
                Brand = brand.Brand,
                Id = brand.Id
            };

            return ExecuteSafeAsync(() => _catalogBrandRepository.Update(brandRepo));
        }
    }
}
