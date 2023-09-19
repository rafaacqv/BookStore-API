

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories
{
  public interface IBaseRepository<T> where T : class, IEntity
  {
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(int id, T entity);
    Task DeleteAsync(int id);
  }
}
