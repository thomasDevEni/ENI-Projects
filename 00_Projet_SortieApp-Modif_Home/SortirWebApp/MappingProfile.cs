using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using AutoMapper;
using Domain.Entities;

namespace SortieWebApp
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Etat, EtatDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Libelle, opt => opt.MapFrom(src => src.Libelle));
            CreateMap<Inscription,InscriptionDto>();
            CreateMap<Lieu,LieuDto>();
            CreateMap<Participant,ParticipantDto>();
            CreateMap<Role,RoleDto>();
            CreateMap<Sortie,SortieDto>();

        }
    }
}
