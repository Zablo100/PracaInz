using FluentValidation;
using pracaInż.Models.Entities.CompanyStructure;

namespace pracaInż.Validators
{
    public class FactoryValidator : AbstractValidator<Factory>
    {
        public FactoryValidator()
        {
            RuleFor(Factory => Factory.City)
                .NotEmpty()
                .WithMessage("Pole jest wymagane!");

        }
    }
}
