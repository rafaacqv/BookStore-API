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

    public ProductService(IBaseRepository<Product> baseRepository, IMapper mapper) 
    {
      _mapper = mapper;
      _baseRepository = baseRepository;
    }
    public async Task<ProductsListResponse> GetAllProductsAsync(string? sort, int? formatId, int? categoryId)
    {
      var spec = new ProductsWithCategoriesAndFormatsSpecification(sort, formatId, categoryId);
      var productsList = await _baseRepository.GetAllWithSpecAsync(spec);

      var response = new ProductsListResponse()
      {
        Products = _mapper.Map<List<ProductResponse>>(productsList.ToList())
      };
      
      return response;
    }

    public async Task<ProductResponse> GetProductByIdAsync(int id)
    {
      var spec = new ProductsWithCategoriesAndFormatsSpecification(id);
        
      var product = await _baseRepository.GetEntityWithSpecAsync(spec);
      var response = _mapper.Map<ProductResponse>(product);

      return response;
    }
  }
}
