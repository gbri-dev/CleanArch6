using CleanArch.Domain.Entities;
using FluentAssertions;

namespace CleanArch.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id Value.");
        }
        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionInvalidShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Name too short, minimum 3 characters");
        }
        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionNameNull()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }
        [Fact]
        public void CreateCategory_WithNullNameValue_ResultObjectValidState()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArch.Domain.Validation.DomainExceptionValidation>();                
        }

    }
}