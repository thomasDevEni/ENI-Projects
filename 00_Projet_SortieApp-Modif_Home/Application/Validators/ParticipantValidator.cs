using Domain.Entities;
using FluentValidation;
using Application.Dto;

namespace Application.Validators
{
    public class ParticipantValidator : AbstractValidator<Participant>
    {
        public ParticipantValidator()
        {
            RuleFor(x => x.Nom).NotEmpty().WithMessage("Le libéllé de l'état est recquis");
            // Add more validation rules as needed
        }
    }
}
