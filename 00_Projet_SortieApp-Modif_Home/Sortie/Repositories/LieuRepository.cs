using Domain.Entities;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LieuRepository:ILieuRepository
    {
        public readonly LieuContext _context;

        public LieuRepository(LieuContext context)
        {
            _context = context;
        }

        public void AddLieu(Lieu lieu)
        {
            try
            {
                _context.Lieu.Add(lieu);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
