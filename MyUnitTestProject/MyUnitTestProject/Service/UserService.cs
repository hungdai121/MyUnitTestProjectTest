using MyUnitTestProject.Infrastructure;
using MyUnitTestProject.Models;

namespace MyUnitTestProject.Service
{
    public interface IUserService
    {
        public List<User> GetUsersByName(string name);
        public bool IsUserBelow20(int id);
        public bool AddUser(User user);

    }

    public class UserService: IUserService
    {
        private readonly ApplicationDbContext _contest;

        public UserService(ApplicationDbContext contest)
        {
            _contest = contest;
        }

        public bool IsUserBelow20(int id)
        {
            return _contest.Users.Any(x => x.Age < 20 && x.Id == id);
        }

        public List<User> GetUsersByName(string name)
        {
            var users = _contest.Users.Where(x => x.Name == name);
            if (users != null)
            {
                return users.ToList();
            }
            return null;
        }

        public bool AddUser(User user)
        {
            // Add fail when user is null or user id exist in list user
            if (user == null)
            {
                return false;
            }
            else if(_contest.Users.Any(x => x.Id == user.Id))
            {
                return false;
            }

            // Add new user
            _contest.Users.Add(user);

            _contest.SaveChanges();

            return true;
        }
    }
}
