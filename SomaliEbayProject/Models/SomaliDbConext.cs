using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SomaliEbayProject.Models
{
    public class SomaliDbConext : DbContext
    {
        //1- Create Ctor
        public SomaliDbConext(DbContextOptions<SomaliDbConext> dbContext) :base(dbContext)
        {

        }
        //2- OnCreateModel
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        //3- add your Model DbSets
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
