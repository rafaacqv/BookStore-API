﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUC.PosGraduacao.BookStore.Domain.DTO
{
  public class BaseResponse
  {
    public int HttpStatusCode { get; set; }
    public List<string> Message { get; set; } = new List<string>();
  }
}
