using App.Repositories.Products;
using App.Services.Models.Product;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace App.Services.Models.Validators
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductRequestValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(p => p.Name)
                .NotNull().WithMessage("Product Name is Required.")
                .NotEmpty().WithMessage("Product Name is Required.")
                .Length(3, 30).WithMessage("Product Name length should be between 3-30.");
                //.Must(MustUniqueProductName)
                //.MustAsync(MustUniqueProductNameAsync);

            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Product Price should be greater than 0.");

            RuleFor(p => p.Stock)
                //.GreaterThanOrEqualTo(0).WithMessage("Product Stock should be greater than or equal to 0.")
                .InclusiveBetween(1, 100).WithMessage("Product Stock should be between 1-100.");
        }

        #region Validation Methods

        // 1. way : Synchronous method to check uniqueness of product name (Unit validation)
        private bool MustUniqueProductName(string name)
        {
            return !_productRepository.Where(p => p.Name == name).Any();
        }

        // 2. way : Asynchronous method to check uniqueness of product name (Unit validation)
        private async Task<bool> MustUniqueProductNameAsync(string name, CancellationToken cancellationToken)
        {
            return !await _productRepository.Where(p => p.Name == name).AnyAsync(cancellationToken);
        }

        #endregion
    }
}
