using JobPortal_JobConnect.DBContext;
using JobPortal_JobConnect.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal_JobConnect.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int userId);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> CreateUserAsync(User user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly JobPortalDbContext _context;

        public UserRepository(JobPortalDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
