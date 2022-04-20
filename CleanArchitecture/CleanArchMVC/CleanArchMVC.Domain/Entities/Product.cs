using CleanArchMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Product : Entity
    {
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;

            ValidateDomain(name, description, price, stock, image);
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        //public int Id { get; private set; } // Não vi necessidade de criar uma classe abstrata para isso, fiz apenas por didatica do curso

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public void Update(string name, string description, decimal price, int stock, string image, int categoryId) 
        {

            ValidateDomain(name, description, price, stock, image);
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), $"Invalid name. {nameof(Name)} is Required");
            DomainExceptionValidation.When(name.Trim().Length < 3, $"Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), $"Invalid description. {nameof(Description)} is Required");
            DomainExceptionValidation.When(name.Trim().Length < 5, $"Invalid name, too short, minimum 5 characters");

            DomainExceptionValidation.When(image.Trim().Length > 250, $"Invalid image name, too long, maximum 250 characters");

            DomainExceptionValidation.When(price < 0, $"Invalid {nameof(Price)} value.");
            DomainExceptionValidation.When(stock < 0, $"Invalid {nameof(Stock)} value.");
        }
    }
}
