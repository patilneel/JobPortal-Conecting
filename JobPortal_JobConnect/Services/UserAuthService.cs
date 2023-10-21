using JobPortal_JobConnect.Models;
using JobPortal_JobConnect.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace JobPortal_JobConnect.Services
{    

    namespace JobPortal_JobConnect.Services
    {
        public interface IUserAuthService
        {
            UserAuthModel GetUserByUsername(string username, string password);
            void Register(UserAuthModel model);
        }

        public class UserAuthService : IUserAuthService
        {
            private readonly IUserAuthRepository _userRepository;
            private readonly IPasswordHasher<UserAuthModel> _passwordHasher;

            public UserAuthService(IUserAuthRepository userRepository, IPasswordHasher<UserAuthModel> passwordHasher)
            {
                _userRepository = userRepository;
                _passwordHasher = passwordHasher;
            }

            public UserAuthModel GetUserByUsername(string username, string password)
            {
                UserAuthModel user = _userRepository.GetUserByUsername(username);

                if (user == null || _passwordHasher.VerifyHashedPassword(user, user.UserAuthPassword, password) != Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success)
                {
                    return null; // Invalid credentials
                }

                return user;
            }

            public void Register(UserAuthModel model)
            {
                // Implement registration logic here, including password hashing and validation.
                var user = new UserAuthModel
                {
                    UserAuthName = model.UserAuthName,
                    UserAuthPassword = _passwordHasher.HashPassword(null, model.UserAuthPassword)
                };
                _userRepository.AddUser(user);
            }
        }
    }


}
