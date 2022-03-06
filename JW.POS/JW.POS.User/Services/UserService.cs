using JW.POS.User.Models;

namespace JW.POS.User
{
    public interface IUserService
    {
        Task<bool> IsValidUserAccountAsync(UserLogin user);
    }

    public class UserService : IUserService
    {
        public UserService()
        {

        }

        public Task<bool> IsValidUserAccountAsync(UserLogin user)
        {
            
        }
    }
}