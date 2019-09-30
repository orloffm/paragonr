﻿namespace Paragonr.Application.Interfaces
{
    public interface IPasswordService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

        bool IsPasswordPresent(byte[] storedHash, byte[] storedSalt);

        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
    }
}
