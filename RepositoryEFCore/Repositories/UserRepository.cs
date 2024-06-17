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

        public int CreateUser(User user)
        {
            Context.Add(user);
            Context.SaveChanges();
            return user.UserId; 
        }
        public User DeleteUser(int id)
        {
            var userToDelete = ReadUser(id);
            if (userToDelete != null)
            {
                var deletedUser = Context.Remove(userToDelete).Entity;
                Context.SaveChanges(); 
                return deletedUser;
            }
            return null;
        }
        public IEnumerable<User> ReadAllUsers() => 
            Context.Users.ToList();
        public User ReadUser(int id) => 
            Context.Users.FirstOrDefault(u => u.UserId == id) ?? null;
        public bool UpdatePasswordUser(User user) => 
            Context.Users.Update(user) != null;
        public bool UpdateUser(User user) => 
            Context.Users.Update(user) != null;

        public bool UpgradeUser(User user) => 
            Context.Users.Update(user) != null;

        public User LoginUser(string userName)
        {
            return Context.Users.SingleOrDefault(u =>
           u.UserName.ToLower() == userName.ToLower() &&
           u.Restore == false &&
           u.Confirmation == true);
        }

        public int ReadUserXEmail(string email)
        {
            var user = Context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            return user.UserId;
        }

    }
}
