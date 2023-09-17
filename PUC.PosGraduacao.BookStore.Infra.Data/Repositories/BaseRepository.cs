using Microsoft.EntityFrameworkCore;
using PUC.PosGraduacao.BookStore.Domain.Interfaces;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Infra.Data.Contexts;

namespace PUC.PosGraduacao.BookStore.Infra.Data.Repositories
{
  public class BaseRepository<T> : IBaseRepository<T> where T: class, IEntity
  {
    private readonly ApplicationDbContext _context;
    public BaseRepository(ApplicationDbContext context)
    {
      _context = context;        
    }

    public async Task Create(T entity)
    {
      await _context.Set<T>().AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      var entity = await GetById(id);
      _context.Set<T>().Remove(entity);
      await _context.SaveChangesAsync();
    }

    public IQueryable<T> GetAll()
    {
      return _context.Set<T>().AsNoTracking();
    }

    public async Task<T> GetById(int id)
    {
      var item =  await _context.Set<T>()
                 .AsNoTracking()
                 .FirstOrDefaultAsync(e => e.Id == id);

      _ = item ?? throw new ArgumentNullException(nameof(item));

      return item;

    }

    public async Task Update(int id, T entity)
    {
      _context.Set<T>().Update(entity);
      await _context.SaveChangesAsync();
    }
  }
}
