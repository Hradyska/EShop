using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<GetData<CatalogBrand>> GetAsync();
        Task<int?> Add(string brand);
        Task<int?> Remove(int id);
        Task<int?> Update(CatalogBrand brand);
    }
}
