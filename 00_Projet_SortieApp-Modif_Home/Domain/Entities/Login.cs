using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int? RoleId { get; set; }

        public int ParticipantId { get; set; }

        public bool IsActive { get; set; }

        public bool Protected { get; set; }

        public virtual ICollection<Participant> Participant { get; set; }
    }
}
