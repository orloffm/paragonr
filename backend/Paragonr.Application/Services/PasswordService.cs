using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Paragonr.Application.Interfaces;
using Paragonr.Domain.Entities;
using Paragonr.Domain.Exceptions;

namespace Paragonr.Application.Services
{
    public sealed class PasswordService : IPasswordService
    {
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            password = AssertPasswordCorrectnessAndGroom(password);

            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public void SetPasswordForUser(string password, User user)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
        }

        public bool IsPasswordSet(User u)
        {
            return u.PasswordSalt?.Length > 0;
        }

        public bool CheckPassword(string password, User u)
        {
            if (!IsPasswordSet(u))
            {
                // No password set - can't authenticate.
                return false;
            }

            password = AssertPasswordCorrectnessAndGroom(password);

            if (u.PasswordHash?.Length != 64)
            {
                throw new PasswordMustBeResetException($"User {u.Username} has invalid length of password hash (64 bytes expected). Please reset it.");
            }

            if (u.PasswordSalt?.Length != 128)
            {
                throw new PasswordMustBeResetException($"User {u.Username} has invalid length of password salt (128 bytes expected).");
            }

            using var hmac = new HMACSHA512(u.PasswordSalt);

            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != u.PasswordHash[i])
                {
                    return false;
                }
            }

            return true;
        }

        private string AssertPasswordCorrectnessAndGroom(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new PasswordNoProperProvidedException();
            }

            password = password.Trim();

            return password;
        }
    }
}
