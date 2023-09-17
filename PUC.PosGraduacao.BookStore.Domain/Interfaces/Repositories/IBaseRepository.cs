using System.Security.Principal;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories
{
  public interface IBaseRepository<T> where T : class, IEntity
  {
    IQueryable<T> GetAll();
    Task<T> GetById(int id);
    Task Create(T entity);
    Task Update(int id, T entity);
    Task Delete(int id);
  }
}
