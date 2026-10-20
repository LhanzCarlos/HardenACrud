
using System.ComponentModel.DataAnnotations;

namespace HardenCRUD.Models;

public class CreateProductRequest : IValidatableObject
{
    [Required(ErrorMessage = "Product name is required.")]
    [StringLength(100, MinimumLength = 2,
        ErrorMessage = "Name must be 2 to 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Range(typeof(decimal), "0.01", "1000000",
        ErrorMessage = "Price must be greater than 0 and at most 1,000,000.")]
    public decimal Price { get; set; }

    [Range(typeof(decimal), "0.01", "1000000",
        ErrorMessage = "Sale price must be greater than 0.")]
    public decimal? SalePrice { get; set; }

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        if (SalePrice.HasValue && SalePrice.Value >= Price)
        {
            yield return new ValidationResult(
                "Sale price must be lower than the regular price.",
                new[] { nameof(SalePrice), nameof(Price) });
        }
    }
}
