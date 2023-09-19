using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Services
{
  public interface IFormatService
  {
    Task<IReadOnlyList<Format>> GetAllFormatsAsync();
    Task<Format> GetFormatByIdAsync(int id);
  }
}
