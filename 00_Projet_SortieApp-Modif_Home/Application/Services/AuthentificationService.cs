using Application.Dto;
using Application.Validators;
using AutoMapper;
using FluentValidation;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;

namespace Application.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IMapper _mapper;
        private readonly IUtilisateurRepository _userRepository;
        private readonly IValidator<UtilisateurDto> _userValidator;
        private readonly IValidator<AuthentificationDto> _loginValidator;


        public AuthentificationService(IMapper mapper, IUtilisateurRepository userRepository, IValidator<UtilisateurDto> userValidator, IValidator<AuthentificationDto> loginValidator)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userValidator = userValidator;
            _loginValidator = loginValidator;
        }
        public ValidationResult ValidateUser(UtilisateurDto user)
        {
            return _userValidator.Validate(user);
        }

        public ValidationResult ValidateLogin(AuthentificationDto login)
        {
            return _loginValidator.Validate(login);
        }

        //Hash the Password During Login Registration
        public static string HashPassword(string password)
        {
            // Create an instance of PasswordHasher
            var hasher = new PasswordHasher<string>();

            // Hash the password
            return hasher.HashPassword(null, password);
        }

        public async Task AddUserAsync(UtilisateurDto userDto)
        {
            //If validation is ok, Add user to database
            try
            {
                // On hashe le mot de passe en clair 
                string HashedPassword = HashPassword(userDto.Password);
                userDto.Password = HashedPassword;
                // Map ParticipanttDto to Participant entity
                var userEntity = _mapper.Map<Utilisateur>(userDto);

                // Pass the mapped entity to the repository for addition
                await _userRepository.AddUserAsync(userEntity);


            }
            catch (Exception ex)

            {
                throw new Exception(ex.Message);
            }
        }

        public static bool VerifyPassword(string plainTextPassword, string hashedPassword)
        {
            // Create an instance of PasswordHasher
            var hasher = new PasswordHasher<string>();

            // Verify the password
            var result = hasher.VerifyHashedPassword(null, hashedPassword, plainTextPassword);

            // Result will be PasswordVerificationResult.Success if the password matches
            return result == PasswordVerificationResult.Success;
        }

        //Verify Hashed Password During Authentication
        public async Task<bool> AuthenticateLoginAsync(AuthentificationDto loginDto)
        {
            // Retrieve the hashed password from your database based on the username
            var hashedPasswordFromDatabase = await _userRepository.GetHashedPassword(loginDto.Username);

            // Verify the password
            bool isValidPassword = VerifyPassword(loginDto.Password, hashedPasswordFromDatabase.Password);

            return isValidPassword;
        }
    }
}
