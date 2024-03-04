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
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;

namespace Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IValidator<LoginDto> _userValidator;


        public LoginService(IMapper mapper, IUserRepository userRepository, IValidator<LoginDto> userValidator)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userValidator = userValidator;
        }
        public ValidationResult ValidateUser(LoginDto user)
        {
            return _userValidator.Validate(user);
        }

        //Hash the Password During Login Registration
        public static string HashPassword(string password)
        {
            // Create an instance of PasswordHasher
            var hasher = new PasswordHasher<string>();

            // Hash the password
            return hasher.HashPassword(null, password);
        }

        public async Task AddUserAsync(LoginDto userDto)
        {
            //If validation is ok, Add user to database
            try
            {
                // On hashe le mot de passe en clair 
                string HashedPassword = HashPassword(userDto.Password);
                userDto.Password = HashedPassword;
                // Map ParticipanttDto to Participant entity
                var userEntity = _mapper.Map<Login>(userDto);

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
        public async Task<bool> AuthenticateLoginAsync(LoginDto loginDto)
        {
            // Retrieve the hashed password from your database based on the username
            var hashedPasswordFromDatabase = await _userRepository.GetHashedPassword(loginDto.Username);

            // Verify the password
            bool isValidPassword = VerifyPassword(loginDto.Password, hashedPasswordFromDatabase.Password);

            return isValidPassword;
        }
    }
}
