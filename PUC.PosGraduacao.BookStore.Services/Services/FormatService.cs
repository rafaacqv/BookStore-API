using PUC.PosGraduacao.BookStore.Domain.Interfaces.Repositories;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Services;
using PUC.PosGraduacao.BookStore.Domain.Models;
using PUC.PosGraduacao.BookStore.Infra.Data.Repositories;

namespace PUC.PosGraduacao.BookStore.Services.Services
{
  public class FormatService : IFormatService
  {
    private readonly IBaseRepository<Format> _baseRepository;

    public FormatService(IBaseRepository<Format> baseRepository)
    {
      _baseRepository = baseRepository;
    }

    public async Task<IReadOnlyList<Format>> GetAllFormatsAsync()
    {
      return await _baseRepository.GetAllAsync();
    }

    public async Task<Format> GetFormatByIdAsync(int id)
    {
      return await _baseRepository.GetByIdAsync(id);
    }
  }
}
