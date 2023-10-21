using JobPortal_JobConnect.Models;
using JobPortal_JobConnect.Repository;

namespace JobPortal_JobConnect.Services
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int userId);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> CreateUserAsync(User user);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> GetUserAsync(int userId)
        {
            return _userRepository.GetUserAsync(userId);
        }

        public Task<User> GetUserByUsernameAsync(string username)
        {
            return _userRepository.GetUserByUsernameAsync(username);
        }

        public Task<User> CreateUserAsync(User user)
        {
            return _userRepository.CreateUserAsync(user);
        }
    }
}
