using PUC.PosGraduacao.BookStore.Domain.Interfaces;

namespace PUC.PosGraduacao.BookStore.Domain.Models
{
  public class Product : IEntity
  {
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; } 
    public string? Author { get; set; }
    public string? Isbn { get; set; }  
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
    public Format? Format { get; set; }
    public int FormatId { get; set; }
  }
}
