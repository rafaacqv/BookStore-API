﻿using Microsoft.EntityFrameworkCore;
using PUC.PosGraduacao.BookStore.Domain.Interfaces.Specifications;
using PUC.PosGraduacao.BookStore.Domain.Models;

namespace PUC.PosGraduacao.BookStore.Infra.Data.Specification
{
  public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
  {
    public static IQueryable<TEntity>GetQuery(IQueryable<TEntity> inputQuery,
      ISpecification<TEntity> spec)
    {
      var query = inputQuery;

      if(spec.Criteria != null)
      {
        query = query.Where(spec.Criteria);
      }

      if(spec.OrderBy != null)
      {
        query = query.OrderBy(spec.OrderBy);
      }

      if(spec.OrderByDescending != null)
      {
        query = query.OrderByDescending(spec.OrderByDescending);
      }

      if (spec.isPagingEnabled)
      {
        query = query.Skip(spec.Skip).Take(spec.Take);
      }

      query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
      return query;
    }
  }
}
