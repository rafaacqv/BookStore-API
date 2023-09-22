using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.DTO
{
  public class ProductsListResponse
  {
    public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
  }
}
