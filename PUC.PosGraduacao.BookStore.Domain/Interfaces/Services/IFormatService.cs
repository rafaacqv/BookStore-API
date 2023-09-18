using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Services
{
  public interface IFormatService
  {
    Task<List<Format>> GetAllFormats();
    Task<Format> GetFormatById(int id);
  }
}
