using AppraisalTracker.Data;
using AppraisalTracker.Exceptions;
using AppraisalTracker.Modules.Login;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppraisalTracker.Modules.Users.Service
{
    public interface IUsersService
    {
        Task<User> AddUser(User newUser);
        Task<User> GetSingleUser(Guid userId);
        Task<List<User>> GetAllUsers();
        Task<User> DeleteUser(Guid userId);
        Task<UserLoginViewModel> AuthenticateUser(string username, string password);
    }

    public class UserService : IUsersService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> AddUser(User newUser)
        {
            var entityEntry = await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<UserLoginViewModel> AuthenticateUser(string username, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                var data = new UserLoginViewModel 
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                return data;
            }
            else
            {
                throw new ClientFriendlyException("Invalid username or password");
            }
        }

        public async Task<User> DeleteUser(Guid userId)
        {
            var userToDelete = await _context.Users.FindAsync(userId);

            if (userToDelete == null)
            {
                throw new ClientFriendlyException("User does not exist");
            }

            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return userToDelete;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetSingleUser(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserId == userId);

            if (user == null)
            {
                throw new ClientFriendlyException("User does not exist");
            }

            return user;
        }
    }
}
