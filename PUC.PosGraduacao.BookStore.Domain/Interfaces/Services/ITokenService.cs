using PUC.PosGraduacao.BookStore.Domain.Models.Identity;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Services
{
  public interface ITokenService
  {
    string CreateToken(AppUser user);
  }
}
