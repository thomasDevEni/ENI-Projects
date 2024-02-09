using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EtatService : IEtatService
    {
        public EtatRepository _retatRepository { get; set; }

        public EtatService(EtatRepository retatRepository)
        {
            _retatRepository = retatRepository;
        }

        public void AddEtat(Etat etat)
        {
            try
            {
                _retatRepository.AddEtat(etat);

            }
            catch (Exception ex)

            { throw new Exception(); }
        }
    }
}
