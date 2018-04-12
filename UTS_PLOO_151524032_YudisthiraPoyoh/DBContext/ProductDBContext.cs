using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UTS_PLOO_151524032_YudisthiraPoyoh.Models;

namespace UTS_PLOO_151524032_YudisthiraPoyoh.DBContext
{
    public class ProductDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}