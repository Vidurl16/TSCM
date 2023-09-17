using System;
using System.Collections.Generic;
using API.Repository.Models;

namespace API.Repository
{
    public interface IUserRepository
    {
        // Data access related to Users
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
