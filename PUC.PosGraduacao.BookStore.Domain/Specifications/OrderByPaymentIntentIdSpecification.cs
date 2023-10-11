using PUC.PosGraduacao.BookStore.Domain.Models.Order;
namespace PUC.PosGraduacao.BookStore.Domain.Specifications
{
  public class OrderByPaymentIntentIdSpecification : BaseSpecification<Order>
  {
    public OrderByPaymentIntentIdSpecification(string paymentIntentId)
      :base(o => o.PaymentIntentId == paymentIntentId)
    {

    }
  }
}
