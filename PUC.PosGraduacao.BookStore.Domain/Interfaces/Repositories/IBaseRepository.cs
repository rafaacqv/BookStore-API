

using PUC.PosGraduacao.BookStore.Domain.Interfaces.Specifications;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories
{
  public interface IBaseRepository<T> where T : class, IEntity
  {
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(int id, T entity);
    Task DeleteAsync(int id);
    Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec);
    Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);
    Task<int> CountAsync(ISpecification<T> spec);
  }
}
