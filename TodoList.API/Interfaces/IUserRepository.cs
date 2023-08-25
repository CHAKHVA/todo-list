using System;
using TodoList.API.Models;

namespace TodoList.API.Interfaces
{
	public interface IUserRepository
	{
        Task<User> GetUserById(int id);
        Task<User> GetUserByUsername(string username);
        Task CreateUser(User user);
        Task UpdateUser(int id, User user);
        Task DeleteUser(int id);
    }
}

