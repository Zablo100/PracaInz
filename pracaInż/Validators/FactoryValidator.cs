using FluentValidation;
using pracaInż.Models.Entities.CompanyStructure;

namespace pracaInż.Validators
{
    public class FactoryValidator : AbstractValidator<Factory>
    {
        public FactoryValidator()
        {
            RuleFor(Factory => Factory.City)
                .NotEmpty().WithMessage("Pole miasto jest wymagane!")
                .MaximumLength(100).WithMessage("Pole miasto zawiera zbyt dużo znaków!")
                .Must(BeValidName).WithMessage("Pole miasto może składać się tylko z liter!");

            RuleFor(Factory => Factory.Street)
                .NotEmpty().WithMessage("Pole ulica jest wymagane!")
                .MaximumLength(100).WithMessage("Pole ulica zawiera zbyt dużo znaków!")
                .Must(BeValidName).WithMessage("Pole ulica może składać się tylko z liter!");

            RuleFor(Factory => Factory.StreetNumber)
                .NotEmpty().WithMessage("Pole ulica jest wymagane!")
                .GreaterThan(0).WithMessage("Numer budynku nie może być mniejszy od 1!");

        }

        public bool BeValidName(string name)
        {
            return name.All(char.IsLetter);
        }
    }
}
