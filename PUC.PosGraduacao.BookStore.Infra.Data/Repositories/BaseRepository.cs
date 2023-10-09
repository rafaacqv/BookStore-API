using Microsoft.EntityFrameworkCore;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Specifications;
using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Infra.Data.Contexts;
using PUC.PosGraduacao.BookStore.Infra.Data.Specification;

namespace PUC.PosGraduacao.BookStore.Infra.Data.Repositories
{
  public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
  {
    private readonly ApplicationDbContext _context;
    public BaseRepository(ApplicationDbContext context)
    {
      _context = context;        
    }

    public void Create(T entity)
    {
      _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
      _context.Set<T>().Remove(entity); 
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
      var element = await _context.Set<T>().FindAsync(id);
      return element;
    }

    public void Update(T entity)
    {
      _context.Set<T>().Attach(entity);
      _context.Entry(entity).State = EntityState.Modified;
    }

    public async Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec)
    {
      return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
    {
      return await ApplySpecification(spec).ToListAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
      return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
      return await ApplySpecification(spec).CountAsync();
    }
  }
}
