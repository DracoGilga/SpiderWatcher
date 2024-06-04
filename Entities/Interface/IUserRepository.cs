using Entities.Poco;

namespace Entities.Interface
{
    public interface IUserRepository
    {
        int CreateUser(User user);
        User ReadUser(int id);
        bool UpdateUser(User user);
        User DeleteUser(int id);

        IEnumerable<User> ReadAllUsers();
        bool UpdatePasswordUser(User user);
        bool UpgradeUser(User user);
        User LoginUser(User user);         
    }
}
