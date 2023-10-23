using FluentValidation;
using pracaInż.Models.DTO.Departments;

namespace pracaInż.Validators
{
    public class DepartmentValidation : AbstractValidator<AddDepartmentDTO>
    {
        public DepartmentValidation() 
        {
            RuleFor(dep => dep.Name)
                .NotEmpty().WithMessage("Tole nazwa nie może być pusta!");
        }
    }
}
