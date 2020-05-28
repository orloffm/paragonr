using System;
using System.Linq;
using System.Threading;
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

        public async Task<User> AssertAuthorityToOperateOn(Guid requestUserRefKey, string password)
        {
            // Get the requested user.
            User user = await _context.Users.GetByRefKeyOrDefault(requestUserRefKey);
            if (user == null)
            {
                throw new UserNotFoundException(requestUserRefKey);
            }

            // Can the current user manipulate it?
            long currentUserId = _currentUserService.GetCurrentUserId();
            if (currentUserId != user.Id)
            {
                bool isAdmin = await CheckIsAdmin(currentUserId);
                if (!isAdmin)
                {
                    throw new MustBeAdminException();
                }
            }
            else
            {
                bool matches = _passService.CheckPassword(password, user);
                if (!matches)
                {
                    bool isAdmin = await CheckIsAdmin(currentUserId);
                    if (!isAdmin)
                    {
                        throw new PasswordIncorrectException();
                    }
                }
            }

            return user;
        }

        private async Task<bool> CheckIsAdmin(long currentUserId)
        {
            return await _context.Users.GetPropertyByIdOrNull(currentUserId, u => u.IsAdmin) ?? false;
        }

        public async Task<User> AuthenticateOrFail(string userQuery, string password)
        {
            // Get the user.
            User user = await FindUserByLoginStringOrDefault(userQuery);
            if (user == null)
            {
                throw new UserNotFoundException(userQuery);
            }

            if (!_passService.IsPasswordSet(user))
            {
                _passService.SetPasswordForUser(password, user);
                await _context.SaveChangesAsync(CancellationToken.None);

                return user;
            }

            // Check the password.
            bool matches = _passService.CheckPassword(password, user);
            if (!matches)
            {
                throw new PasswordIncorrectException();
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
