using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string Nom{ get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public int RoleId { get; set; }

        public bool IsActive { get; set; }
    }
}
