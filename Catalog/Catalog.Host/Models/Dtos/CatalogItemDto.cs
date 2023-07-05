using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Dtos
{
    public class CatalogItemDto
    {
        [Required]
        [Range(1, 100, ErrorMessage = "The field ID have to be > 0.")]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Maximum lenth of the field Name is 50 characters.")]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Required]
        [Range(0.0, double.MaxValue)]
        public decimal Price { get; set; }

        public string PictureUrl { get; set; } = null!;

        public CatalogTypeDto CatalogType { get; set; } = null!;

        public CatalogBrandDto CatalogBrand { get; set; } = null!;

        public int AvailableStock { get; set; }
    }
}
