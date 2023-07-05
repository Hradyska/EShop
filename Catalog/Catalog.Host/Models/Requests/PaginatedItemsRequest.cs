using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class PaginatedItemsRequest<T>
            where T : notnull
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int PageIndex { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int PageSize { get; set; }

        public Dictionary<T, int>? Filters { get; set; }
    }
}
