using PUC.PosGraduacao.BookStore.Domain.Enums;

namespace PUC.PosGraduacao.BookStore.Domain.DTO
{
  public class BaseResponse
  {
    public StatusCodeEnum HttpStatus { get; set; }
    public List<string> Message { get; set; } = new List<string>();
  }
}
