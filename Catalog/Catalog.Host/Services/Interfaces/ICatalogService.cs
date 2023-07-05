using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Responses;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<PaginatedItemsResponse<CatalogItemDto>?> GetCatalogItemsAsync(int pageSize, int pageIndex, Dictionary<CatalogTypeFilter, int>? filters);
        Task<GetResponse<CatalogBrandDto>> GetCatalogBrandsAsync();
        Task<GetResponse<CatalogTypeDto>> GetCatalogTypesAsync();
        Task<GetResponse<CatalogItemDto>> GetCatalogItemsByIdAsync(int id);
        Task<GetResponse<CatalogItemDto>> GetCatalogItemsByBrandAsync(int brandId);
        Task<GetResponse<CatalogItemDto>> GetCatalogItemsByTypeAsync(int typeId);
    }
}
