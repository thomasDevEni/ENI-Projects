using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace Application
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Etat,EtatDto>();
            CreateMap<Inscription,InscriptionDto>();
            CreateMap<Lieu,LieuDto>();
            CreateMap<Participant,ParticipantDto>();
            CreateMap<Role,RoleDto>();
            CreateMap<Sortie,SortieDto>();

        }
    }
}
