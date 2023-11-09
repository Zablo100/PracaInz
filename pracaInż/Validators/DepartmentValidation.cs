using FluentValidation;
using pracaInż.Models.DTO.Departments;

namespace pracaInż.Validators
{
    public class DepartmentValidation : AbstractValidator<AddDepartmentDTO>
    {
        public DepartmentValidation() 
        {
            RuleFor(dep => dep.Name)
                .NotEmpty().WithMessage("Pole nazwa nie może być pusta!")
                .Must(BeValidName).WithMessage("Pole nazwa może składać się tylko z liter!")
                .MinimumLength(5).WithMessage("Nazwa zbyt krótka!");


            RuleFor(dep => dep.ShortName)
                .NotEmpty().WithMessage("Pole skrót nie może być pusta!")
                .Must(BeValidName).WithMessage("Pole skrót może składać się tylko z liter!")
                .MinimumLength(1).WithMessage("Pole skrót musi zawierać co najmniej 2 znaki!")
                .MaximumLength(5).WithMessage("Pole skrót musi być krótsze niż 5 znaków!");

            RuleFor(dep => dep.InvoiceCode)
                .NotEmpty().WithMessage("Kod jednostki organizacyjnej nie może być pusty!")
                .MaximumLength(20).WithMessage("Kod jednostki organizacyjnej jest zbyt długi!")
                .MinimumLength(5).WithMessage("Kod jednostki organizacyjnej ejst zbyt krótki!");

            RuleFor(dep => dep.FactoryId)
                .NotEmpty().WithMessage("Nie przypisany działu do żadnej fabryki");
        }

        public bool BeValidName(string name)
        {
            return name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
    }

    public class UpdateDepartmentValidation : AbstractValidator<UpdateDepartmentDTO>
    {
        public UpdateDepartmentValidation()
        {
            RuleFor(dep => dep.Name)
                .NotEmpty().WithMessage("Pole nazwa nie może być pusta!")
                .Must(BeValidName).WithMessage("Pole nazwa może składać się tylko z liter!")
                .MinimumLength(5).WithMessage("Nazwa zbyt krótka!");


            RuleFor(dep => dep.ShortName)
                .NotEmpty().WithMessage("Pole skrót nie może być pusta!")
                .Must(BeValidName).WithMessage("Pole skrót może składać się tylko z liter!")
                .MinimumLength(1).WithMessage("Pole skrót musi zawierać co najmniej 2 znaki!")
                .MaximumLength(5).WithMessage("Pole skrót musi być krótsze niż 5 znaków!");

            RuleFor(dep => dep.InvoiceCode)
                .NotEmpty().WithMessage("Kod jednostki organizacyjnej nie może być pusty!")
                .MaximumLength(20).WithMessage("Kod jednostki organizacyjnej jest zbyt długi!")
                .MinimumLength(5).WithMessage("Kod jednostki organizacyjnej ejst zbyt krótki!");

            RuleFor(dep => dep.FactoryId)
                .NotEmpty().WithMessage("Nie przypisany działu do żadnej fabryki");
        }

        public bool BeValidName(string name)
        {
            return name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
    }


}
