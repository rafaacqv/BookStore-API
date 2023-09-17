using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Services.Services
{
  public class ProductService : IProductService
  {
    private readonly IBaseRepository<Product> _baseRepository;
    public ProductService(IBaseRepository<Product> baseRepository) 
    {
      _baseRepository = baseRepository;
    }
    public async Task<List<Product>> GetAllProducts()
    {
      return _baseRepository.GetAll().ToList();
    }

    public async Task<Product> GetProductById(int id)
    {
      return await _baseRepository.GetById(id);
    }
  }
}
