using CleanArchMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Category : Entity
    {
        public Category(int id, string name)
        {

            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;

            ValidationName(name);
            this.Name = name;
        }

        public Category(string name)
        {
            ValidationName(name);
        }

        //public int Id { get; private set; } // Não vi necessidade de criar uma classe abstrata para isso, fiz apenas por didatica do curso
        public string Name { get; private set; }

        public IEnumerable<Product> Products { get; set; }

        public void Update(string name) 
        {
            ValidationName(name);
            this.Name = name;
        }
        
        private void ValidationName(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is Required");
            DomainExceptionValidation.When(name.Trim().Length < 3, "Invalid name, too short, minimum 3 characters");
        }
    }
}
