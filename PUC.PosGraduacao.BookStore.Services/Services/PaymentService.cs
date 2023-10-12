using Microsoft.Extensions.Configuration;
using PUC.PosGraduacao.BookStore.Domain.Interfaces;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Domain.Models.Order;
using PUC.PosGraduacao.BookStore.Domain.Specifications;
using Stripe;

namespace PUC.PosGraduacao.BookStore.Services.Services
{
  public class PaymentService : IPaymentService
  {
    private readonly IBasketRepository _basketRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public PaymentService(IBasketRepository basketRepository, IUnitOfWork unitOfWork, IConfiguration configuration)
    {
      _basketRepository = basketRepository;
      _unitOfWork = unitOfWork;
      _configuration = configuration;
    }

    public async Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId)
    {
      StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];
      var basket = await _basketRepository.GetBasketAsync(basketId);
      if (basket == null) return null;
      
      var shippingPrice = 0m;

      if(basket.DeliveryMethodId.HasValue)
      {
        var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>()
          .GetByIdAsync((int)basket.DeliveryMethodId);
        shippingPrice = deliveryMethod.Price;
      }

      foreach(var item in basket.Items)
      {
        var productItem = await _unitOfWork.Repository<Domain.Models.Product>().GetByIdAsync(item.Id);
        if(item.Price != productItem.Price)
        {
          item.Price = productItem.Price;
        }
      }

      var service = new PaymentIntentService();
      PaymentIntent intent;

      if(string.IsNullOrEmpty(basket.PaymentIntentId))
      {
        var options = new PaymentIntentCreateOptions
        {
          Amount = (long)basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long)shippingPrice * 100,
          Currency = "usd",
          PaymentMethodTypes = new List<string> { "card" }
        };

        intent = await service.CreateAsync(options);
        basket.PaymentIntentId = intent.Id;
        basket.ClientSecret = intent.ClientSecret;
      }
      else
      {
        var options = new PaymentIntentUpdateOptions
        {
          Amount = (long)basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long)shippingPrice * 100
        };
        await service.UpdateAsync(basket.PaymentIntentId, options);
      }

      await _basketRepository.UpdateBasketAsync(basket);
      return basket;
    }

    public async Task<Order> UpdateOrderPaymentFailed(string paymentIntentId)
    {
      var spec = new OrderByPaymentIntentIdSpecification(paymentIntentId);
      var order = await _unitOfWork.Repository<Order>().GetEntityWithSpecAsync(spec);

      if (order == null) return null;

      order.Status = OrderStatus.PaymentFailed;
      await _unitOfWork.Complete();
      
      return order;
    }

    public async Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId)
    {
      var spec = new OrderByPaymentIntentIdSpecification(paymentIntentId);
      var order = await _unitOfWork.Repository<Order>().GetEntityWithSpecAsync(spec);

      if (order == null) return null;

      order.Status = OrderStatus.PaymentRecevied;
      await _unitOfWork.Complete();

      return order;
    }
  }
}
