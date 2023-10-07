using System.ComponentModel.DataAnnotations;

namespace PUC.PosGraduacao.BookStore.Domain.DTO
{
  public class BasketItemDTO
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public string ProductName { get; set; }
    [Required]
    [Range(0.1, double.MaxValue, ErrorMessage ="Price must be greater than zero")]
    public decimal Price { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage ="Quantity must be at least 1")]
    public int Quantity { get; set; }
    [Required]
    public string? ImageUrl { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Format { get; set; }
  }
}
