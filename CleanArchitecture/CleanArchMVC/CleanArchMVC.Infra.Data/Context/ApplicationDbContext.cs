using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Infra.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //modelBuilder.ApplyConfiguration(new CategoryConfiguration()); -> este código não é necessário, pois o de cima consegue identificar as config por meio da herança de "IEntityTypeConfiguration"
            //Essa identificação é feita através de reflection, é pego as config de quem tiver implementando "IEntityTypeConfiguration" 
        }

    }
}
