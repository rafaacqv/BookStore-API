using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Services
{
  public interface IFormatService
  {
    Task<FormatsListResponse> GetAllFormatsAsync();
    Task<FormatResponse> GetFormatByIdAsync(FormatRequest request);
  }
}
