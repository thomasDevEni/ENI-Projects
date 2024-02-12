using Domain.Entities;
using FluentValidation;
using Application.Dto;

namespace Application.Validators
{
    public class RoleValidator : AbstractValidator<RoleDto>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Libelle).NotEmpty().WithMessage("Le libéllé du rôle est recquis");
            // Add more validation rules as needed
        }
    }
}
