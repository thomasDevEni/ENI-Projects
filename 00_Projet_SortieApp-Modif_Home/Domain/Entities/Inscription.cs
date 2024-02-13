using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inscription
    {
        public int Id { get; set; }
        public string ParticipantId { get; set; }
        public string SortieId { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<Sortie> Sorties { get; set; }
    
    }
}
