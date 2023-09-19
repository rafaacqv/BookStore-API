using PUC.PosGraduacao.BookStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUC.PosGraduacao.BookStore.Domain.Models
{
  public class BaseEntity : IEntity
  {
    public int Id { get; set; }
  }
}
