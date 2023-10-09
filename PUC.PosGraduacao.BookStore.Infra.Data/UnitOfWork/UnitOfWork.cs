using PUC.PosGraduacao.BookStore.Domain.Interfaces;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Infra.Data.Contexts;
using PUC.PosGraduacao.BookStore.Infra.Data.Repositories;
using System.Collections;

namespace PUC.PosGraduacao.BookStore.Infra.Data.UnitOfWork
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly ApplicationDbContext _context;
    private Hashtable _repositories;

    public UnitOfWork(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<int> Complete()
    {
      return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
      _context.Dispose();
    }

    public IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
      if(_repositories == null) _repositories = new Hashtable();

      var type = typeof(TEntity).Name;

      if(!_repositories.ContainsKey(type))
      {
        var repositoryType = typeof(BaseRepository<>);
        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

        _repositories.Add(type, repositoryInstance);
      }

      return (IBaseRepository<TEntity>) _repositories[type];
    }
  }
}
