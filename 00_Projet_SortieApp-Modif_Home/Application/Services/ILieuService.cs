using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ILieuService
    {
        Task AddLieuAsync(LieuDto lieuDto);
        Task<LieuDto> GetByIdAsync(int id);
        Task<List<LieuDto>> GetAllLieuAsync();

        Task<LieuDto> GetLieuByIdAsync(int id);
    }
}
