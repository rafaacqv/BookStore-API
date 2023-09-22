using AutoMapper;
using Microsoft.Extensions.Logging;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Domain.Specifications;

namespace PUC.PosGraduacao.BookStore.Services.Services
{
  public class ProductService : IProductService
  {
    private readonly IBaseRepository<Product> _baseRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IBaseRepository<Product> baseRepository, IMapper mapper, ILogger<ProductService> logger) 
    {
      _logger = logger;
      _mapper = mapper;
      _baseRepository = baseRepository;
    }
    public async Task<ProductsListResponse> GetAllProductsAsync()
    {
      var response = new ProductsListResponse();
      try
      {
        var spec = new ProductsWithCategoriesAndFormatsSpecification();
        var productsList = await _baseRepository.GetAllWithSpecAsync(spec);
        response.Products = _mapper.Map<List<ProductDTO>>(productsList.ToList());
      }
      catch (Exception ex)
      {
        _logger.LogError("Error while trying to fetch products list. Error: {error}, Stack: {stack}", ex.Message, ex.Message);
      }
      return response;
    }

    public async Task<ProductsResponse> GetProductByIdAsync(int id)
    {
      var response = new ProductsResponse();
      try
      {
        var spec = new ProductsWithCategoriesAndFormatsSpecification(id);
        var product = await _baseRepository.GetEntityWithSpecAsync(spec);
        response.Product = _mapper.Map<ProductDTO>(product);
      }
      catch (Exception ex)
      {
        _logger.LogError("Error while trying to fetch a product. Error: {error}, Stack: {stack}", ex.Message, ex.Message);
      }
      return response;
    }
  }
}
