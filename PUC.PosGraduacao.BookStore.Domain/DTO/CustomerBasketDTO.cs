using System.ComponentModel.DataAnnotations;

namespace PUC.PosGraduacao.BookStore.Domain.DTO
{
  public class CustomerBasketDTO
  {
    [Required]
    public string Id { get; set; }
    public List<BasketItemDTO> Items { get; set; } = new List<BasketItemDTO>();
    public int? DeliveryMethodId { get; set; }
    public string? ClientSecret { get; set; }
    public string? PaymentIntentd { get; set; }
    public decimal ShippingPrice { get; set; }
  }
}
