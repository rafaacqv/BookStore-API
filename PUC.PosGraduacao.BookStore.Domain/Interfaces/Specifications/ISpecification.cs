﻿using System.Linq.Expressions;

namespace PUC.PosGraduacao.BookStore.Domain.Interfaces.Specifications
{
    public interface ISpecification<T>
    {
      Expression<Func<T, bool>> Criteria { get; }
      List<Expression<Func<T, object>>> Includes { get; }
    }
}