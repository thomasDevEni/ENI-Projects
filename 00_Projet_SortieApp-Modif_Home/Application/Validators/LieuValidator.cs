using Domain.Entities;
using FluentValidation;
using Application.Dto;

namespace Application.Validators
{
    public class LieuValidator : AbstractValidator<LieuDto>
    {
        public LieuValidator()
        {
            RuleFor(x => x.Etablissement).NotEmpty().WithMessage("L'Etablissement est obligatoire").MaximumLength(28).WithMessage("L'Etablissement ne doit pas dépasser 28 caractères.");
            RuleFor(x => x.Adresse).NotEmpty().WithMessage("L'adresse est obligatoire").MaximumLength(28).WithMessage("L'adresse ne doit pas dépasser 28 caractères."); ;
            RuleFor(x => x.Ville).NotEmpty().WithMessage("La ville est obligatoire").MaximumLength(28).WithMessage("La ville ne doit pas dépasser 28 caractères.");
            RuleFor(x => x.CodePostal).NotEmpty().WithMessage("Le code postal est obligatoire").Matches(@"^\d{5}(?:[-\s]\d{4})?$").WithMessage("Format de Code Postal invalide."); ;
            RuleFor(x => x.CoordonneeGPS).NotEmpty().WithMessage("Les coordonnées GPS sont necessaires");
        }
    }
}
