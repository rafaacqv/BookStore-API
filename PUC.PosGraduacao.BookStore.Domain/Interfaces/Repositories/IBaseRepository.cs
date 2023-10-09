

using PUC.PosGraduacao.BookStore.Domain.Interfaces.Specifications;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories
{
  public interface IBaseRepository<T> where T : class, IEntity
  {
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec);
    Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);
    Task<int> CountAsync(ISpecification<T> spec);
    void Create(T entity);
    void Update(T entity);
    void Delete(T Entity);

  }
}
