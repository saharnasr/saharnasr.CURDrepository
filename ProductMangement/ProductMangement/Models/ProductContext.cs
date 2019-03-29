using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductMangement.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("myconnection")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
