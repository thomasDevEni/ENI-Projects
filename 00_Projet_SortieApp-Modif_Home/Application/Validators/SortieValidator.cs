using Domain.Entities;
using FluentValidation;
using Application.Dto;

namespace Application.Validators
{
    public class SortieValidator : AbstractValidator<SortieDto>
    {
        public SortieValidator()
        {
            RuleFor(x => x.Nom).NotEmpty().WithMessage("Le nom est obligatoire");
            RuleFor(x => x.DateDebut).NotNull().NotEmpty().WithMessage("La date de début est obligatoire");
            RuleFor(x => x.OrganisateurId).NotNull().NotEmpty().WithMessage("Id de l'organisateur OBLIGATOIRE");
            RuleFor(x => x.LieuId).NotNull().NotEmpty().WithMessage("Id de lieu OBLIGATOIRE");
            RuleFor(x => x.EtatId).NotNull().NotEmpty().WithMessage("Id de l'état OBLIGATOIRE");
        }
    }
}
