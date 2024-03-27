using Entities.Interface;
using Entities.Poco;
using RepositoryEFCore.DataContext;

namespace RepositoryEFCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly SpiderWatcherContext Context;
        public UserRepository(SpiderWatcherContext context) 
            => Context = context;

        public void CreateUser(User user) => Context.Add(user);
        public void DeleteUser(int id) => Context.Remove(ReadUser(id));
        public IEnumerable<User> ReadAllUsers() => 
            Context.Users ?? null;
        public User ReadUser(int id) => 
            Context.Users.FirstOrDefault(u => u.UserId == id) ?? null;
        public bool UpdatePasswordUser(User user) => 
            Context.Users.Update(user) != null;
        public bool UpdateUser(User user) => 
            Context.Users.Update(user) != null;
        public bool UpgradeUser(User user) => 
            Context.Users.Update(user) != null;

        public User LoginUser(User user)
        {
            var foundUser = Context.Users.FirstOrDefault(u =>
                u.UserName == user.UserName &&
                u.Password == user.Password);

            return foundUser ?? null;
        }
    }
}
