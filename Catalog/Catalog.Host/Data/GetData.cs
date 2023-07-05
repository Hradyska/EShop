namespace Catalog.Host.Data
{
    public class GetData<T>
    {
        public IEnumerable<T> Data { get; set; } = null!;
    }
}
