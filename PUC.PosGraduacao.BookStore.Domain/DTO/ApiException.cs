using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUC.PosGraduacao.BookStore.Domain.DTO
{
  public class ApiException : ApiResponse
  {
    public ApiException(int statusCode, string message = null, string details = null) : base(statusCode, message)
    {
      Details = details;
    }

    public string Details { get; set; }
  }
}
