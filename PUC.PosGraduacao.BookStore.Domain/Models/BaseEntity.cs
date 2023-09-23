using PUC.PosGraduacao.BookStore.Domain.Interfaces;

namespace PUC.PosGraduacao.BookStore.Domain.Models
{
  public class BaseEntity : IEntity
  {
    public int Id { get; set; }
  }
}
