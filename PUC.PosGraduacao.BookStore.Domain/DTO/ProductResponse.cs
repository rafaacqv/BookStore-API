using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.DTO
{
  public class ProductResponse : BaseEntity
  {
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public string? Author { get; set; }
    public string? Isbn { get; set; }
    public string? Category { get; set; }
    public string? Format { get; set; }
  }
}
