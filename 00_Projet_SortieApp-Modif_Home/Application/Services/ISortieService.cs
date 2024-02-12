using Application.Dto;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ISortieService
    {
        Task AddSortieAsync(SortieDto sortieDto);
        Task<SortieDto> GetByIdAsync(int id);
        Task<List<SortieDto>> GetAllSortieAsync();

        Task<SortieDto> GetSortieByIdAsync(int id);

        ValidationResult ValidateSortie(SortieDto sortie);
    }
}
