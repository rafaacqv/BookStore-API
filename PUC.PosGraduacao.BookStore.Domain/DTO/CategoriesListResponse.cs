using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.DTO
{
  public class CategoriesListResponse
  {
    public List<Category> Categories { get; set; } = new List<Category>();
  }
}
