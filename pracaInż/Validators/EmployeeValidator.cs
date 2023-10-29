using pracaInż.Models.DTO.Employees;
using FluentValidation;

namespace pracaInż.Validators
{
    public class AddEmployeeValidator : AbstractValidator<AddEmployeeBasiInfoDTO>
    {
        public AddEmployeeValidator()
        {
            RuleFor(Employee => Employee.Name)
                .NotEmpty().WithMessage("Pole Imię nie możę być puste!")
                .MinimumLength(2).WithMessage("Pole Imię ma zbyt mało znaków!")
                .MaximumLength(100).WithMessage("Pole Imię ma zbyt dużo znaków!")
                .Must(BeValidName).WithMessage("Polę Imię nie może zawierać innyc hznaków niż litery!");

            RuleFor(Employee => Employee.Surname)
                .NotEmpty().WithMessage("Pole Nazwisko nie możę być puste!")
                .MinimumLength(2).WithMessage("Pole Nazwisko ma zbyt mało znaków!")
                .MaximumLength(100).WithMessage("Pole Nazwisko ma zbyt dużo znaków!")
                .Must(BeValidName).WithMessage("Polę Nazwisko nie może zawierać innyc hznaków niż litery!");

            RuleFor(Employee => Employee.Email)
                .NotEmpty().WithMessage("Pole Email nie mozę być puste!")
                .Must(BeValidaEmailAddress).WithMessage("Podany Email jest nieprawidłowy!");

        }

        public bool BeValidName(string name)
        {
            return name.All(char.IsLetter);
        }

        public bool BeValidaEmailAddress(string emial)
        {
            //TODO: Walidacja maila
            return true;
        }
    }

    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeDTO>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(Employee => Employee.Name)
                .NotEmpty().WithMessage("Pole Imię nie możę być puste!")
                .MinimumLength(2).WithMessage("Pole Imię ma zbyt mało znaków!")
                .MaximumLength(100).WithMessage("Pole Imię ma zbyt dużo znaków!")
                .Must(BeValidName).WithMessage("Polę Imię nie może zawierać innyc hznaków niż litery!");

            RuleFor(Employee => Employee.Surname)
                .NotEmpty().WithMessage("Pole Nazwisko nie możę być puste!")
                .MinimumLength(2).WithMessage("Pole Nazwisko ma zbyt mało znaków!")
                .MaximumLength(100).WithMessage("Pole Nazwisko ma zbyt dużo znaków!")
                .Must(BeValidName).WithMessage("Polę Nazwisko nie może zawierać innyc hznaków niż litery!");

            RuleFor(Employee => Employee.Email)
                .NotEmpty().WithMessage("Pole Email nie mozę być puste!")
                .Must(BeValidaEmailAddress).WithMessage("Podany Email jest nieprawidłowy!");

        }

        public bool BeValidName(string name)
        {
            return name.All(char.IsLetter);
        }

        public bool BeValidaEmailAddress(string emial)
        {
            //TODO: Walidacja maila
            return true;
        }
    }
}
