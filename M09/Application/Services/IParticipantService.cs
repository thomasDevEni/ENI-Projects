using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal interface IParticipantService
    {
        void AddParticipant(Participant participant);
    }
}
