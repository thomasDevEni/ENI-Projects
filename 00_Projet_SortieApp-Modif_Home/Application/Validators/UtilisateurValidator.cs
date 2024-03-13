using Application.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class UtilisateurValidator : AbstractValidator<UtilisateurDto>
    {
        public UtilisateurValidator() 
        {
            RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MinimumLength(3).WithMessage("Username must be at least 3 characters.")
            .MaximumLength(20).WithMessage("Username cannot exceed 20 characters.")
            .Matches(@"^[a-zA-Z0-9_]+$").WithMessage("Username can only contain letters, numbers, and underscores.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
                .MaximumLength(30).WithMessage("Password cannot exceed 30 characters.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Le Nom est obligatoire");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Le Prénom est obligatoire");
            RuleFor(x => x.Mail).Must(BeAValidAdress).NotEmpty().WithMessage("L'adresse mail doit être valide");
           // RuleFor(x => x.RoleId).NotEmpty().WithMessage("Le libéllé de l'état est recquis");
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
