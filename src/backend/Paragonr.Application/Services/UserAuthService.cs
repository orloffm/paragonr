using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paragonr.Application.Interfaces;
using Paragonr.Domain;
using Paragonr.Domain.Entities;
using Paragonr.Domain.Exceptions;
using Paragonr.Tools.EntityFramework.Extensions;

namespace Paragonr.Application.Services
{
    public sealed class UserAuthService : IUserAuthService
    {
        private readonly IBudgetDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IPasswordService _passService;

        public UserAuthService(IBudgetDbContext context, IPasswordService passService, ICurrentUserService currentUserService)
        {
            _context = context;
            _passService = passService;
            _currentUserService = currentUserService;
        }

        public async Task<User> AssertAuthority(Guid requestUserRefKey, string requestOldPassword)
        {
            // Get the requested user.
            User user = await _context.Users.GetByRefKeyOrDefault(requestUserRefKey);
            if (user == null)
            {
                throw new UserNotFoundException(requestUserRefKey);
            }

            // Can the current user manipulate it?
            var currentUserId = _currentUserService.GetCurrentUserId();
            if (currentUserId == user.Id)
            {
                var matches = _passService.VerifyPasswordHash(requestOldPassword, user.PasswordHash, user.PasswordSalt);
                if (!matches)
                {
                    throw new IncorrectPasswordException();
                }
            }
            else
            {
                var isAdmin = await _context.Users.GetPropertyByIdOrNull(currentUserId, u => u.IsAdmin) ?? false;
                if (!isAdmin)
                {
                    throw new MustBeAdminException();
                }
            }

            return user;
        }

        public async Task<User> AuthenticateOrFail(string userQuery, string password)
        {
            // Get the user.
            User user = await FindUserByLoginStringOrDefault(userQuery);

            if (user == null)
            {
                throw new UserNotFoundException(userQuery);
            }

            // Check the password.
            var matches = _passService.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            if (!matches)
            {
                throw new IncorrectPasswordException();
            }

            return user;
        }

        private async Task<User> FindUserByLoginStringOrDefault(string requestUser)
        {
            User user = await _context.Users.Select(
                    u => new
                    {
                        User = u,
                        LoginMatches = u.Username == requestUser,
                        EmailMatches = u.Email == requestUser
                    }
                )
                .Where(g => g.LoginMatches || g.EmailMatches)
                .OrderByDescending(g => g.LoginMatches)
                .ThenByDescending(g => g.EmailMatches)
                .Select(g => g.User)
                .FirstOrDefaultAsync();

            return user;
        }
    }
}
