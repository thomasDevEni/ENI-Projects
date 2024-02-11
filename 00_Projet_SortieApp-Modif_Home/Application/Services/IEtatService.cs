using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IEtatService
    {
        Task AddEtatAsync(EtatDto etatDto);
        Task<EtatDto> GetByIdAsync(int id);
        Task<List<EtatDto>> GetAllEtatAsync();

        Task<EtatDto> GetEtatByIdAsync(int id);


    }
}
