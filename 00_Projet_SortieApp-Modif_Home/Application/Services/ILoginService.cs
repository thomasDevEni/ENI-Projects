using Application.Dto;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ILoginService
    {
        //Task LoginAsync(UserDto userDto);
        ValidationResult ValidateUser(LoginDto user);
        //string HashPassword(string password);
        //bool VerifyPassword(string plainTextPassword, string hashedPassword);
        Task AddUserAsync(LoginDto userDto);
        Task<bool> AuthenticateLoginAsync(LoginDto userDto);

    }
}
