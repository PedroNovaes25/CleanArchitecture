using CleanArchMVC.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMVC.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create category with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create category with invalid id")]
        public void CreateCategory_NegativeIdValue_DomainExceptionValidation()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create category with null name value")]
        public void CreateCategory_WithNullNameValue_DomainExceptionValidation()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is Required");
        }

        [Fact(DisplayName = "Create category with short name value")]
        public void CreateCategory_WithShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Pi");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create category missing name value")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is Required");
        }
    }
}
