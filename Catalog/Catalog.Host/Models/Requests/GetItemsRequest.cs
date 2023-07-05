using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class GetItemsRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The field ID have to be > 0.")]
        public int Id { get; set; }
    }
}
