using PUC.PosGraduacao.BookStore.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace PUC.PosGraduacao.BookStore.Domain.DTO
{
  public class CustomerBasketDTO
  {
    [Required]
    public string Id { get; set; }
    public List<BasketItemDTO> Items { get; set; } = new List<BasketItemDTO>();
  }
}
