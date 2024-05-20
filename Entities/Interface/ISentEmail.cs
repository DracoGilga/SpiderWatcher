using Entities.Poco;

namespace Entities.Interface
{
    public interface ISentEmail
    {
        bool CreateUserEmail(User user);

        bool UpdatePasswordUserEmail(User user);
        bool UpgradeUserEmail(User user);
    }
}
