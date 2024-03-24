using Entities.Poco;

namespace Entities.Interface
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task<User> ReadUser(int id);
        Task UpdateUser(User user);
        Task DeleteUser(int id);

        Task<IEnumerable<User>> ReadAllUsers();
        Task UpdatePasswordUser(User user);
        Task UpgradeUser(User user);
        Task LoginUser(User user);         
    }
}
