using API.Repository.Models;

namespace API.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);
        void UpdateUser(int id, User user);
        void DeleteUser(int id);
        void UpdateUser(User user);
    }

}
