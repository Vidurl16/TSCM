using System;
using System.Collections.Generic;
using System.Linq;
using API.Repository.Models;

namespace API.Repository;

public class UserRepository : IUserRepository
{
    private readonly KCP_DbContext _context;

    public UserRepository(KCP_DbContext context)
    {
        _context = context;
    }

    public User GetUserById(int id)
    {
        return _context.Users.Find(id);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public void CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void DeleteUser(User user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}
