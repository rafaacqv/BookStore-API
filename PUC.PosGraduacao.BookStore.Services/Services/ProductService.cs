using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Domain.Specifications;

namespace PUC.PosGraduacao.BookStore.Services.Services
{
  public class ProductService : IProductService
  {
    private readonly IBaseRepository<Product> _baseRepository;
    public ProductService(IBaseRepository<Product> baseRepository) 
    {
      _baseRepository = baseRepository;
    }
    public async Task<IReadOnlyList<Product>> GetAllProductsAsync()
    {
      var spec = new ProductsSpecification();
      return await _baseRepository.GetAllWithSpecAsync(spec);
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
      return await _baseRepository.GetByIdAsync(id);
    }
  }
}
