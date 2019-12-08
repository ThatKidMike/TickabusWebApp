using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickabusWebApp.DTOs;
using TickabusWebApp.Models;
using TickabusWebApp.Repositories;

namespace TickabusWebApp.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepo _authRepo;
        private readonly IMapper _mapper;

        public AuthService(IAuthRepo authRepo, IMapper mapper)
        {
            _authRepo = authRepo;
            _mapper = mapper;
        }
        public async Task<UserDTO> Login(string username, string password)
        {
            var user = await _authRepo.Login(username, password);

            if (user is null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return _mapper.Map<UserDTO>(user);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }

                return true;
            }

        }

        public async Task<UserDTO> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _authRepo.Register(user);

            return _mapper.Map<UserDTO>(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }
        }

        public async Task<bool> UserExists(string username)
        {
             return await _authRepo.UserExists(username);
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _authRepo.EmailExists(email);
        }

        public async Task<string> UserRole(Guid id)
        {
            return await _authRepo.UserRole(id);
        }
    }
}
