using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class InscriptionService : IInscriptionService
    {
        public InscriptionRepository _rinscriptionRepository { get; set; }

        public InscriptionService(InscriptionRepository rinscriptionRepository)
        {
            _rinscriptionRepository = rinscriptionRepository;
        }

        public void AddInscription(Inscription inscription)
        {
            try
            {
                _rinscriptionRepository.AddInscription(inscription);

            }
            catch (Exception ex)

            { throw new Exception(); }
        }
    }
}
