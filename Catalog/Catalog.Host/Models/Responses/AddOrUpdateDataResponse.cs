namespace Catalog.Host.Models.Responses
{
    public class AddOrUpdateDataResponse<T>
    {
        public T Id { get; set; } = default(T) !;
    }
}
