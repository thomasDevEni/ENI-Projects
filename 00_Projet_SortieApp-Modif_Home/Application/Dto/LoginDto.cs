﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public int ParticipantId { get; set; }
    }
}
