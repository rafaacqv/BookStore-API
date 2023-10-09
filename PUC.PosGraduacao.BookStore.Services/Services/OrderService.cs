using PUC.PosGraduacao.BookStore.Domain.Interfaces;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Domain.Models.Order;
using PUC.PosGraduacao.BookStore.Domain.Specifications;

namespace PUC.PosGraduacao.BookStore.Services.Services
{
  public class OrderService : IOrderService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBasketRepository _basketRepository;

    public OrderService(IUnitOfWork unitOfWork, IBasketRepository basketRepository)
    {
      _unitOfWork = unitOfWork;
      _basketRepository = basketRepository;
    }

    public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
    {
      var basket = await _basketRepository.GetBasketAsync(basketId);
      var items = new List<OrderItem>();

      foreach (var item in basket.Items)
      {
        var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
        var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Title, productItem.ImageUrl);
        var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
        items.Add(orderItem);
      }

      var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);
      var subTotal = items.Sum(item => item.Price * item.Quantity);

      var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subTotal);
      _unitOfWork.Repository<Order>().Create(order);

      var result = await _unitOfWork.Complete();
      if (result <= 0) return null;

      await _basketRepository.DeleteBasketAsync(basketId);
      return order;
    }

    public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
    {
      return await _unitOfWork.Repository<DeliveryMethod>().GetAllAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
    {
      var spec = new OrdersWithItemsAndOrderingSpecification(id, buyerEmail);
      return await _unitOfWork.Repository<Order>().GetEntityWithSpecAsync(spec);
    }

    public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
    {
      var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);
      return await _unitOfWork.Repository<Order>().GetAllWithSpecAsync(spec);
    }
  }
}
