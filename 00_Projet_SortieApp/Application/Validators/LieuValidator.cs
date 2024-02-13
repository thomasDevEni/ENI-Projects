using Domain.Entities;
using FluentValidation;
using Application.Dto;

namespace Application.Validators
{
    public class LieuValidator : AbstractValidator<LieuDto>
    {
        public LieuValidator()
        {
            RuleFor(x => x.Etablissement).NotEmpty().WithMessage("L'Etablissement est obligatoire");
            RuleFor(x => x.Adresse).NotEmpty().WithMessage("L'adresse est obligatoire");
            RuleFor(x => x.Ville).NotEmpty().WithMessage("La ville est obligatoire");
            RuleFor(x => x.CodePostal).NotEmpty().WithMessage("Le code postal est obligatoire");
            RuleFor(x => x.CoordonneeGPS).NotEmpty().WithMessage("Les coordonnées GPS sont necessaires");
        }
    }
}
