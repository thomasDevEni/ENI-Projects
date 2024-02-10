using Domain.Entities;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InscriptionRepository
    {
        public readonly InscriptionContext _context;

        public InscriptionRepository(InscriptionContext context)
        {
            _context = context;
        }

        public void AddInscription(Inscription inscription)
        {
            try
            {
                _context.Inscription.Add(inscription);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
