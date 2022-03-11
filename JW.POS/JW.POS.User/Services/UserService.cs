using JW.POS.Common.Extension;
using JW.POS.Core.Data;
using JW.POS.User.Models;
using Microsoft.EntityFrameworkCore;

namespace JW.POS.User.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Check if given user is valid
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> IsValidUserAccountAsync(UserLogin user);

        /// <summary>
        /// Get User token info
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<UserToken> GetUserInfoAsync(string username);
    }

    public class UserService : IUserService
    {
        private readonly ITenantDbContextFactory _tenantDbContextFactory;
        public UserService(ITenantDbContextFactory tenantDbContextFactory)
        {
            _tenantDbContextFactory = tenantDbContextFactory;
        }

        public async Task<UserToken> GetUserInfoAsync(string username)
        {
            using var context = _tenantDbContextFactory.CreateDbContext();
            return await context.Users
                .Where(u => u.UserName == username)
                .Select(u => new UserToken {
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName
            }).FirstOrDefaultAsync();
        }

        public async Task<bool> IsValidUserAccountAsync(UserLogin user)
        {
            using var context = _tenantDbContextFactory.CreateDbContext();
            var hashPassword = user.Password.Hash();

            var valid = await context.Users
                .AnyAsync(u => u.UserName == user.UserName && u.Password == hashPassword);

            return valid;
        }
    }
}