using Application.Dto;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUtilisateurService
    {
        Task<UtilisateurDto> GetByIdAsync(int id);
        Task<List<UtilisateurDto>> GetAllUtilisateurAsync();

        Task<UtilisateurDto> GetUtilisateurByIdAsync(int id);

        ValidationResult ValidateUtilisateur(UtilisateurDto utilisateur);

        Task UpdateUtilisateurAsync(UtilisateurDto utilisateurDto);

        Task DeleteUtilisateurAsync(int id);
    }
}
