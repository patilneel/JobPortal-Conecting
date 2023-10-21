using JobPortal_JobConnect.DBContext;
using JobPortal_JobConnect.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal_JobConnect.Repository
{
    public interface IUserAuthRepository
    {
        UserAuthModel GetUserByUsername(string username);
        void AddUser(UserAuthModel user);
    }

    public class UserAuthRepository : IUserAuthRepository
    {
        private readonly JobPortalDbContext _context;

        public UserAuthRepository(JobPortalDbContext context)
        {
            _context = context;
        }

        public UserAuthModel GetUserByUsername(string username)
        {
            return _context.UserAuthModels.SingleOrDefault(u => u.UserAuthName == username);
        }

        public void AddUser(UserAuthModel user)
        {
            _context.UserAuthModels.Add(user);
            _context.SaveChanges();
        }
    }

}
