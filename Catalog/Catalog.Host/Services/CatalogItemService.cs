using Catalog.Host.Models.Dtos;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services.Interfaces;
using AutoMapper;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Requests;

namespace Catalog.Host.Services
{
    public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly IMapper _mapper;

        public CatalogItemService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogItemRepository catalogItemRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _catalogItemRepository = catalogItemRepository;
            _mapper = mapper;
        }

        public Task<int?> Add(CreateProductRequest item)
        {
            CatalogItem itemRepo = new CatalogItem()
             {
                Name = item.Name,
                Price = item.Price,
                Description = item.Description,
                PictureFileName = item.PictureFileName,
                CatalogBrandId = item.CatalogBrandId,
                CatalogTypeId = item.CatalogTypeId,
             };
            return ExecuteSafeAsync(() => _catalogItemRepository.Add(itemRepo));
        }

        public Task<int?> Remove(int id)
        {
            return ExecuteSafeAsync(() => _catalogItemRepository.Remove(id));
        }

        public Task<int?> Update(int id, CreateProductRequest item)
        {
            CatalogItem itemRepo = new CatalogItem()
            {
                Id = id,
                Name = item.Name,
                Price = item.Price,
                Description = item.Description,
                PictureFileName = item.PictureFileName,
                CatalogBrandId = item.CatalogBrandId,
                CatalogTypeId = item.CatalogTypeId,
            };

            return ExecuteSafeAsync(() => _catalogItemRepository.Update(itemRepo));
        }
    }
}
