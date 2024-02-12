using Application.Dto;
using Domain.Entities;
using FluentValidation;

namespace Application.Validators
{
    public class InscriptionValidator : AbstractValidator<InscriptionDto>
    {
        public InscriptionValidator()
        {
            RuleFor(x => x.ParticipantId).NotNull().NotEmpty().WithMessage("Id du Participant OBLIGATOIRE");
            RuleFor(x => x.SortieId).NotNull().NotEmpty().WithMessage("Id de la Sortie OBLIGATOIRE");
        }
    }
}
