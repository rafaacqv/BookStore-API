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

    public async Task CreateAsync(T entity)
    {
      await _context.Set<T>().AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
      var entity = await GetByIdAsync(id);
      _context.Set<T>().Remove(entity);
      await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
      var element = await _context.Set<T>().FindAsync(id);
      _ = element ?? throw new ArgumentNullException(nameof(element));
      
      return element;
    }

    public async Task UpdateAsync(int id, T entity)
    {
      _context.Set<T>().Update(entity);
      await _context.SaveChangesAsync();
    }
  }
}
