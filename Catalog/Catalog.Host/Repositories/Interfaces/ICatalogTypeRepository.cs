using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Requests;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogTypeRepository
    {
        Task<GetData<CatalogType>> GetAsync();
        Task<int?> Add(string type);
        Task<int?> Remove(int id);
        Task<int?> Update(CatalogType type);
    }
}
