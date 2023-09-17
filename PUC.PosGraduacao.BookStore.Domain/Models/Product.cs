using PUC.PosGraduacao.BookStore.Domain.Interfaces;

namespace PUC.PosGraduacao.BookStore.Domain.Models
{
  public class Product : IEntity
  {
    public int Id { get; set; }
    public string? Title { get; set; }
  }
}
