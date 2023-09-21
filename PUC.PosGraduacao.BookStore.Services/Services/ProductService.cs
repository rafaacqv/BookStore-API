using AutoMapper;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Enums;
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
    public async Task<ProductsListResponse> GetAllProductsAsync()
    {
      var response = new ProductsListResponse()
      {
        HttpStatus = StatusCodeEnum.Error
      };

      try
      {
        var spec = new ProductsSpecification();
        var productsList = await _baseRepository.GetAllWithSpecAsync(spec);
        
        response.Products = productsList.ToList();

        if (!response.Products.Any())
        {
          response.HttpStatus = StatusCodeEnum.NoContent;
        }
        else
        {
          response.HttpStatus = StatusCodeEnum.Success;
        }
      }
      catch (Exception ex)
      {
        response.Message.Add($"An error occured: Error: {ex.Message}, StackTrace: {ex.StackTrace}");
      }
      return response;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
      return await _baseRepository.GetByIdAsync(id);
    }
  }
}
