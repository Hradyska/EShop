namespace Catalog.Host.Data
{
    public class PaginatedItems<T>
    {
        public long? TotalCount { get; set; } = null;
        public IEnumerable<T> Data { get; set; } = null!;
    }
}
