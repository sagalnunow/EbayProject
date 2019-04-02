using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomaliEbayProject.Models
{
    public class SomaliDbContext : DbContext
    {
        //1 Create Constructor or Ctor
        public SomaliDbContext(DbContextOptions<SomaliDbContext> dbContext) : base(dbContext)
        {

        }
        //2 OnCreateMode
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        //3 add your model
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
