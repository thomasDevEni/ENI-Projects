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
    public interface IAuthentificationService
    {
        //Task LoginAsync(UserDto userDto);
        ValidationResult ValidateUser(UtilisateurDto user);
        ValidationResult ValidateLogin(AuthentificationDto login);
        //string HashPassword(string password);
        //bool VerifyPassword(string plainTextPassword, string hashedPassword);
        Task AddUserAsync(UtilisateurDto userDto);
        Task<bool> AuthenticateLoginAsync(AuthentificationDto userDto);

    }
}
