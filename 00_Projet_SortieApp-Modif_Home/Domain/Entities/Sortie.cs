using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sortie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public int OrganisateurId { get; set; }
        public int LieuId { get; set; }
        public int EtatId { get; set;}

        public bool IsActive { get; set; }

        public virtual Participant Organisateur { get; set; }
        public virtual Lieu Lieu { get; set; }  
        public virtual Etat Etat { get; set; }  
    }

}
