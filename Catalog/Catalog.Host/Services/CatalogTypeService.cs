using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Models.Dtos;
using AutoMapper;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Services
{
    public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
    {
        private readonly ICatalogTypeRepository _catalogTypeRepository;
        private readonly IMapper _mapper;

        public CatalogTypeService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogTypeRepository catalogTypeRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _catalogTypeRepository = catalogTypeRepository;
            _mapper = mapper;
        }

        public Task<int?> Add(string type)
        {
            return ExecuteSafeAsync(() => _catalogTypeRepository.Add(type));
        }

        public Task<int?> Remove(int id)
        {
            return ExecuteSafeAsync(() => _catalogTypeRepository.Remove(id));
        }

        public Task<int?> Update(CatalogTypeDto type)
        {
            CatalogType brandRepo = new CatalogType()
            {
                Type = type.Type,
                Id = type.Id
            };

            return ExecuteSafeAsync(() => _catalogTypeRepository.Update(brandRepo));
        }
    }
}
