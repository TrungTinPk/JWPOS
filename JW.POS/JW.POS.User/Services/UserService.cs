using JW.POS.User.Models;

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
        Task<UserToken> GetUserTokenInfoAsync(string username);
    }

    public class UserService : IUserService
    {
        public UserService()
        {

        }

        public Task<UserToken> GetUserTokenInfoAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsValidUserAccountAsync(UserLogin user)
        {
            throw new NotImplementedException();
        }
    }
}