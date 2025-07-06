using FluentValidation;

namespace App.Services.Models.Validators
{
    public class CreateProductRequestValidator:AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("Product Name is Required.")
                .NotEmpty().WithMessage("Product Name is Required.")
                .Length(3,30).WithMessage("Product Name length should be between 3-30.");

            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Product Price should be greater than 0.");

            RuleFor(p => p.Stock)
                //.GreaterThanOrEqualTo(0).WithMessage("Product Stock should be greater than or equal to 0.")
                .InclusiveBetween(1,100).WithMessage("Product Stock should be between 1-100.");
        }
    }
}
