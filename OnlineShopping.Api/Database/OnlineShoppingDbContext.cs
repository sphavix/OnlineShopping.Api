using Microsoft.EntityFrameworkCore;
using OnlineShopping.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Api.Database
{
    public class OnlineShoppingDbContext:DbContext
    {
        public OnlineShoppingDbContext(DbContextOptions<OnlineShoppingDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
