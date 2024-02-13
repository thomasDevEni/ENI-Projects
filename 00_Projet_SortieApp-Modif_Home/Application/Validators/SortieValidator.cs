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
            RuleFor(dateRange => dateRange.DateDebut)
            .NotEmpty().WithMessage("La date de début est obligatoire.")
            .Must(BeAValidDate).WithMessage("Format de Date invalide.")
            .Must((dateRange, DateDebut) => DateDebut <= dateRange.DateFin || dateRange.DateFin == DateTime.MinValue)
            .WithMessage("La date de debut doit-etre au moins egale à la date de fin.");
            RuleFor(dateRange => dateRange.DateFin)
                .Must((dateRange, endDate) => endDate >= dateRange.DateDebut || dateRange.DateDebut == DateTime.MinValue || endDate == DateTime.MinValue)
                .WithMessage("La date de fin doit être au moins supérieure à la date de début.")
                .When(dateRange => dateRange.DateFin != DateTime.MinValue);
            RuleFor(x => x.OrganisateurId).NotNull().NotEmpty().WithMessage("Id de l'organisateur OBLIGATOIRE");
            RuleFor(x => x.LieuId).NotNull().NotEmpty().WithMessage("Id de lieu OBLIGATOIRE");
            RuleFor(x => x.EtatId).NotNull().NotEmpty().WithMessage("Id de l'état OBLIGATOIRE");
        }
        private bool BeAValidDate(DateTime date)
        {
            // Example: Check if the date is within a reasonable range, e.g., between 1900 and current year.
            return date >= new DateTime(1, 1, 1950) && date <= DateTime.Now;
        }

        private bool BeAValidDateFin(DateTime date)
        {
            // Example: Check if the date is within a reasonable range, e.g., between 1900 and current year.
            return date <= new DateTime(1, 1, 1950) && date >= DateTime.Now;
        }
    }
}
