using Domain.Entities;
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
        public LieuRepository _rlieuRepository { get; set; }

        public LieuService(LieuRepository rlieuRepository)
        {
            _rlieuRepository = rlieuRepository;
        }

        public void AddLieu(Lieu lieu)
        {
            try
            {
                _rlieuRepository.AddLieu(lieu);

            }
            catch (Exception ex)

            { throw new Exception(); }
        }
    }
}
