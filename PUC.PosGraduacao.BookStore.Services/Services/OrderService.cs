using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Domain.Models.Order;

namespace PUC.PosGraduacao.BookStore.Services.Services
{
  public class OrderService : IOrderService
  {
    private readonly IBaseRepository<Order> _orderRepository;
    private readonly IBaseRepository<Product> _productRepository;
    private readonly IBaseRepository<DeliveryMethod> _deliveryRepository;
    private readonly IBasketRepository _basketRepository;

    public OrderService(IBaseRepository<Order> orderRepository, 
                        IBaseRepository<Product> productRepository, 
                        IBaseRepository<DeliveryMethod> deliveryRepository, 
                        IBasketRepository basketRepository)
    {
      _orderRepository = orderRepository;
      _productRepository = productRepository;
      _deliveryRepository = deliveryRepository;
      _basketRepository = basketRepository;
    }

    public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
    {
      var basket = await _basketRepository.GetBasketAsync(basketId);
      var items = new List<OrderItem>();

      foreach (var item in basket.Items)
      {
        var productItem = await _productRepository.GetByIdAsync(item.Id);
        var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Title, productItem.ImageUrl);
        var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
        items.Add(orderItem);
      }

      var deliveryMethod = await _deliveryRepository.GetByIdAsync(deliveryMethodId);
      var subTotal = items.Sum(item => item.Price * item.Quantity);

      var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subTotal);
      // Save to database
      return order;
    }

    public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
    {
      throw new NotImplementedException();
    }

    public Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
    {
      throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
    {
      throw new NotImplementedException();
    }
  }
}
