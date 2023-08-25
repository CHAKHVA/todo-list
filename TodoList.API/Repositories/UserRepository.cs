using System;
using Microsoft.EntityFrameworkCore;
using TodoList.API.Data;
using TodoList.API.Models;

namespace TodoList.API.Repositories
{
    public class UserRepository
    {
        private readonly TodoContext _context;

        public UserRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(int id, User user)
        {
            var existingUser = await _context.Users.FindAsync(id);

            existingUser.Username = user.Username;
            existingUser.PasswordHash = user.PasswordHash;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}

