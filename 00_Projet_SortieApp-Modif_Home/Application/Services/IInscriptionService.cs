using Application.Dto;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IInscriptionService
    {
        Task AddInscriptionAsync(InscriptionDto inscriptionDto);
        Task<InscriptionDto> GetByIdAsync(int id);
        Task<List<InscriptionDto>> GetAllInscriptionAsync();

        Task<InscriptionDto> GetInscriptionByIdAsync(int id);

        ValidationResult ValidateInscription(InscriptionDto inscription);
    }
}
