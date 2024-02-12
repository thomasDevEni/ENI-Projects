using Domain.Entities;
using FluentValidation;
using Application.Dto;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Application.Validators
{
    public class ParticipantValidator : AbstractValidator<ParticipantDto>
    {
        public ParticipantValidator()
        {
            RuleFor(x => x.Nom).NotEmpty().WithMessage("Le Nom est obligatoire");
            RuleFor(x => x.Prenom).NotEmpty().WithMessage("Le Prénom est obligatoire");
            RuleFor(x => x.Mail).Must(BeAValidAdress).NotEmpty().WithMessage("L'adresse mail doit être valide");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Le libéllé de l'état est recquis");
        }

        private static bool BeAValidAdress(string emailAddress)
        {
            // Regular expression pattern for validating email addresses
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                           + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(@"
                           + @"(?<publicDomain>(?!-)[a-z0-9-]{1,63}(?<!-)"
                           + @"(\.(?!-)[a-z0-9-]{1,63}(?<!-))*)"
                           + @"|@(?<ipAddress>\[([0-9]{1,3}\.){3}[0-9]{1,3}\]))$";

            // Create Regex object
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            // Check if the email address matches the pattern
            return regex.IsMatch(emailAddress);
        }
    }
}
