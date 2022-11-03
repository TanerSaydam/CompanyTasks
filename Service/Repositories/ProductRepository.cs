using Application.Repositories;
using DataAccess.Context;
using Entity.Entities;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
