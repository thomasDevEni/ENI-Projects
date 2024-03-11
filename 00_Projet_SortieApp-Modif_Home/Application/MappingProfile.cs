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
            //Configuration du mapper pour GET et POST
            CreateMap<EtatDto, Etat>();
            CreateMap<Etat, EtatDto>();
            CreateMap<Inscription,InscriptionDto>();
            CreateMap<InscriptionDto,Inscription>();
            CreateMap<Lieu,LieuDto>();
            CreateMap<LieuDto,Lieu>();
            CreateMap<Participant,ParticipantDto>();
            CreateMap<ParticipantDto,Participant>();
            CreateMap<RoleDto,Role>();
            CreateMap<Role,RoleDto>();
            CreateMap<Sortie,SortieDto>();
            CreateMap<SortieDto,Sortie>();
            CreateMap<Utilisateur, AuthentificationDto>();
            CreateMap<AuthentificationDto, Utilisateur>();
            CreateMap<Utilisateur, UtilisateurDto>();
            CreateMap<UtilisateurDto, Utilisateur>();

        }
    }
}
