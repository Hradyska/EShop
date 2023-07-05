namespace Catalog.Host.Models.Responses
{
    public class GetResponse<T>
    {
        public IEnumerable<T> Data { get; init; } = null!;
    }
}
