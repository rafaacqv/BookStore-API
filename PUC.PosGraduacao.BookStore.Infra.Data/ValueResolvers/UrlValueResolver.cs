using AutoMapper;
using Microsoft.Extensions.Configuration;
using PUC.PosGraduacao.BookStore.Domain.DTO;
using PUC.PosGraduacao.BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUC.PosGraduacao.BookStore.Infra.Data.ValueResolvers
{
    public class UrlValueResolver : IValueResolver<Product, ProductResponse, string>
    {
        private readonly IConfiguration _configuration;

        public UrlValueResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductResponse destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _configuration["ApiUrl"] + source.ImageUrl;
            }

            return null;
        }
    }
}
