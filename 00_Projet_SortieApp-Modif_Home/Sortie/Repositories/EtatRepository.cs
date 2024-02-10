using Domain.Entities;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EtatRepository:IEtatRepository
    {
        public readonly EtatContext _context;

        public EtatRepository(EtatContext context)
        {
            _context = context;
        }

        public void AddEtat(Etat etat)
        {
            try
            {
                _context.Etat.Add(etat);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
