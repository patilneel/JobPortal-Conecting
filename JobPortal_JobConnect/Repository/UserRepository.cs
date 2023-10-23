using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using JobPortal_JobConnect.DBContext;
using JobPortal_JobConnect.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JobPortal_JobConnect.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int userId);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
    }

    public class UserRepository : IUserRepository
    {
        private readonly JobPortalDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(JobPortalDbContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
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
            try
            {
                new UserValidator().ValidateAndThrow(user); 
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (ValidationException ex)
            {
                _logger.LogError(ex, "User creation validation failed.");
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the user.");
                throw ex;
            }
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            try
            {
                new UserValidator().ValidateAndThrow(user); 
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return user;
            }
            catch (ValidationException ex)
            {
                _logger.LogError(ex, "User update validation failed.");
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the user.");
                throw ex;
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
