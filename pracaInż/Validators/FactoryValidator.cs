using FluentValidation;
using pracaInż.Models.DTO.Factories;
using pracaInż.Models.Entities.CompanyStructure;

namespace pracaInż.Validators
{
    public class UpdateFactoryValidator : AbstractValidator<FactoryWithDepartmentDTO>
    {
        public UpdateFactoryValidator()
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

            RuleFor(Factory => Factory.PostalCode)
                .NotEmpty().WithMessage("Pole kod pocztowy nie moze być puste!")
                .Must(BeValidPostalCode).WithMessage("Podano błędny kod pocztowy!");
        }

        private bool BeValidPostalCode(string arg)
        {
            return true; //TODO: Wprowadzić walidacje
        }

        public bool BeValidName(string name)
        {
            return name.All(char.IsLetter);
        }
    }
    public class FactoryValidator : AbstractValidator<AddFactoryDTO>
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

            RuleFor(Factory => Factory.PostalCode)
                .NotEmpty().WithMessage("Pole kod pocztowy nie moze być puste!")
                .Must(BeValidPostalCode).WithMessage("Podano błędny kod pocztowy!");

        }

        private bool BeValidPostalCode(string arg)
        {
            return true; //TODO: Wprowadzić walidacje
        }

        public bool BeValidName(string name)
        {
            return name.All(char.IsLetter);
        }
    }
}
