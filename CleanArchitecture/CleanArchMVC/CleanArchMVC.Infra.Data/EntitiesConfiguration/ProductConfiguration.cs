using CleanArchMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(prod => prod.Id);
            
            builder.Property(prod => prod.Name).HasMaxLength(100).IsRequired();
            builder.Property(prod => prod.Description).HasMaxLength(200).IsRequired();
            
            builder.Property(prod => prod.Price).HasPrecision(10,2);

            builder.HasOne(e => e.Category).WithMany(e => e.Products).HasForeignKey(e => e.CategoryId);
        }
    }
}
