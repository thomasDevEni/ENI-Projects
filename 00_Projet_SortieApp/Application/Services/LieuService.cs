using Application.Dto;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LieuService : ILieuService
    {
        public ILieuRepository _rlieuRepository { get; set; }

        public LieuService(ILieuRepository rlieuRepository)
        {
            _rlieuRepository = rlieuRepository;
        }

        public void AddLieu(LieuDto lieu)
        {
            try
            {
                _rlieuRepository.AddLieu(null);

            }
            catch (Exception ex)

            { throw new Exception(); }
        }
    }
}
