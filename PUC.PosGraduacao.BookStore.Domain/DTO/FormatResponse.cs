﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUC.PosGraduacao.BookStore.Domain.DTO
{
  public class FormatResponse : BaseResponse
  {
    public int Id { get; set; }
    public string? Type { get; set; }
  }
}