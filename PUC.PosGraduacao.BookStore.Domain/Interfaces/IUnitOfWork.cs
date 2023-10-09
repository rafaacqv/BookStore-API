using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces
{
  public interface IUnitOfWork : IDisposable
  {
    IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    Task<int> Complete();
  }
}
