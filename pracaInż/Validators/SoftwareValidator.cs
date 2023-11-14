using FluentValidation;
using pracaInż.Models.DTO.Factories;
using pracaInż.Models.DTO.SoftwareDTOs;

namespace pracaInż.Validators
{
    public class SoftwareValidator : AbstractValidator<SoftwareDTO>
    {
        public SoftwareValidator() 
        {
            RuleFor(Software => Software.Name)
                .NotEmpty().WithMessage("Pole nazwa jest wymagane!")
                .MaximumLength(100).WithMessage("Pole nazwa zawiera zbyt dużo znaków!");
            
            RuleFor(Software => Software.Description)
                .NotEmpty().WithMessage("Pole opis jest wymagane!")
                .MaximumLength(200).WithMessage("Pole opis zawiera zbyt dużo znaków!");

            RuleFor(Sofware => Sofware.Author)
                .NotEmpty().WithMessage("Pole Autor jest wymagane!")
                .MaximumLength(100).WithMessage("Pole Autor zawiera zbyt dużo znaków!");

        }
    }

    public class AddSoftwareValidator : AbstractValidator<AddSoftwareDTO> 
    {
        public AddSoftwareValidator()
        {
            RuleFor(Software => Software.Name)
                .NotEmpty().WithMessage("Pole nazwa jest wymagane!")
                .MaximumLength(100).WithMessage("Pole nazwa zawiera zbyt dużo znaków!");

            RuleFor(Software => Software.Description)
                .NotEmpty().WithMessage("Pole opis jest wymagane!")
                .MaximumLength(200).WithMessage("Pole opis zawiera zbyt dużo znaków!");

            RuleFor(Sofware => Sofware.Author)
                .NotEmpty().WithMessage("Pole Autor jest wymagane!")
                .MaximumLength(100).WithMessage("Pole Autor zawiera zbyt dużo znaków!");
        }
    }
}
