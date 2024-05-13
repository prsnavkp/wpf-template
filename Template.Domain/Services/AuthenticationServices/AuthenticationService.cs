using Template.Domain.Exceptions;
using Template.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Template.Domain.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userDataService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthenticationService(IUserService userDataService, IPasswordHasher<User> passwordHasher)
        {
            _userDataService = userDataService;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> Login(string username, string password)
        {
            User availabeUser = await _userDataService.GetByUsername(username);

            if (availabeUser == null)
            {
                throw new UserNotFoundException(username);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(availabeUser, availabeUser.PasswordHash, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(username, password);
            }

            return availabeUser;
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            User emailAccount = await _userDataService.GetByEmail(email);
            if (emailAccount != null)
            {
                result = RegistrationResult.EmailAlreadyExists;
            }

            User usernameAccount = await _userDataService.GetByUsername(username);
            if (usernameAccount != null)
            {
                result = RegistrationResult.UsernameAlreadyExists;
            }

            if (result == RegistrationResult.Success)
            {
                User user = new User()
                {
                    Email = email,
                    Username = username,
                    DatedJoined = DateTime.Now
                };
                string hashedPassword = _passwordHasher.HashPassword(user, password);
                user.PasswordHash = hashedPassword;

                await _userDataService.Create(user);
            }

            return result;
        }
    }
}