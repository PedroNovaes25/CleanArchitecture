using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(prop => prop.Name).HasMaxLength(100).IsRequired();
            builder.Property(prop => prop.Description).HasMaxLength(200).IsRequired();
            builder.Property(prop => prop.Price).HasPrecision(10,2);

            builder.HasData
                (
                    new Product() 
                    {
                        Id = 1,
                        Name = "Cama elástica",
                        Description = "Boa demais, super elástica e divertida",
                        Price = 230.00m
                    },
                    new Product()
                    {
                        Id = 2,
                        Name = "Pula pula",
                        Description = "Pular pular disversão",
                        Price = 230.00m
                    }, new Product()
                    {
                        Id = 3,
                        Name = "Caderno",
                        Description = "Capa surf, 400 folhas/12 matérias",
                        Price = 25.00m
                    }, new Product()
                    {
                        Id = 4,
                        Name = "Estojo",
                        Description = "Preto e cinza, dois bolsos",
                        Price = 15.00m
                    }
                );

        }
    }
}
