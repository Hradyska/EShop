using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class SetDataRequest
    {
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Maximum lenth of the field Brand is 100 characters.")]
        public string? Name { get; set; }
    }
}
