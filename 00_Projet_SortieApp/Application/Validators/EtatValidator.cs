using Domain.Entities;
using FluentValidation;
using Application.Dto;

namespace Application.Validators
{
    public class EtatValidator : AbstractValidator<EtatDto>
    {
        public EtatValidator()
        {
            RuleFor(x => x.Libelle).NotEmpty().WithMessage("Le libéllé de l'état est recquis");
            // Add more validation rules as needed
        }
    }
}
