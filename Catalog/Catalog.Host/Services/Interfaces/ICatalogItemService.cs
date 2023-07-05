using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogItemService
    {
        Task<int?> Add(CreateProductRequest item);
        Task<int?> Remove(int id);
        Task<int?> Update(int id, CreateProductRequest item);
    }
}
