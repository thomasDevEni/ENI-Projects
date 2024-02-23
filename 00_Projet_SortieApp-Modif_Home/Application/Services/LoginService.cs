using Application.Dto;
using AutoMapper;
using FluentValidation;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LoginService:ILoginService
    {
        private readonly IMapper _mapper;
        private readonly ILoginRepository _rloginRepository;
        private readonly IValidator<LoginDto> _loginValidator;
    }
}
