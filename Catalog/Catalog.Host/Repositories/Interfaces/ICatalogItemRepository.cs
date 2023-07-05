using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogItemRepository
    {
        Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize, int? brandFilter, int? typeFilter);
        Task<GetData<CatalogItem>> GetByIdAsync(int id);
        Task<GetData<CatalogItem>> GetByBrandAsync(int brandId);
        Task<GetData<CatalogItem>> GetByTypeAsync(int typeId);
        Task<int?> Add(CatalogItem item);
        Task<int?> Remove(int id);
        Task<int?> Update(CatalogItem item);
    }
}
