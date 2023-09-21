namespace PUC.PosGraduacao.BookStore.Domain.DTO
{
  public class ProductDTO
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
