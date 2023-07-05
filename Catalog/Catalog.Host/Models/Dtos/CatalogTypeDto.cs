using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Dtos
{
    public class CatalogTypeDto
    {
        [Required]
        [Range(1, 100, ErrorMessage = "The field ID have to be > 0.")]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Maximum lenth of the field Brand is 100 characters.")]
        public string Type { get; set; } = null!;
    }
}
