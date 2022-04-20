using CleanArchMVC.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchMVC.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product with valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 5.90m, 5, "productImage.jpg");

            action.Should().NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product with invalid id")]
        public void CreateProduct_InvalidIdValue_DomainExceptionValidation()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 5.90m, 5, "productImage.jpg");

            action.Should().Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Product with short name value")]
        public void CreateProduct_WithShortName_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 5.90m, 5, "productImage.jpg");

            action.Should().Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create long image name value")]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Produc Name", "Product Description", 5.90m, 5, "productImageaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa.jpg");

            action.Should().Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact(DisplayName = "Create Product with Null image name")]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 5.90m, 5, null);

            action.Should().NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product with Null image name and No NullReferenceException")]
        public void CreateProduct_WithNullImageName_NoNullReferenceException() 
        { 
            Action action = () => new Product(1, "Product Name", "Product Description", 5.90m, 5, null);

            action.Should().NotThrow<NullReferenceException>();
        }


        [Fact(DisplayName = "Create Product with empty image name")]
        public void CreateProduct_WithEmptyName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 5.90m, 5, "");

            action.Should().NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product with invalid price value")]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.90m, 5, "");

            action.Should().Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage($"Invalid {nameof(Product.Price)} value.");
        }

        [Theory(DisplayName = "Create Product invalid Stock value")]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.90m, value, "");

            action.Should().Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage($"Invalid {nameof(Product.Stock)} value.");
        }
    }
}
