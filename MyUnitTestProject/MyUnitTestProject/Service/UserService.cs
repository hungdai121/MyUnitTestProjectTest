using MyUnitTestProject.Infrastructure;
using MyUnitTestProject.Models;

namespace MyUnitTestProject.Service
{
    public interface IUserService
    {
        public List<User> ListUser { get; set; }
        public bool IsUserBelow20(int id);
        public List<User> GetUsersByName(string name);
        public bool AddUser(User user);
        public bool DoSomething(string value);

    }

    public class UserService: IUserService
    {
        public List<User> ListUser { get; set; }

        public UserService()
        {
            ListUser = new List<User>
            {
                new User{Id = 1, Name = "Hung", Age = 24, Nation = "VietNam"},
                new User{Id = 2, Name = "Joe", Age = 17, Nation = "NetherLand"},
                new User{Id = 3, Name = "Sean", Age = 21, Nation = "Mexico"},
                new User{Id = 4, Name = "Daniel", Age = 16, Nation = "Mexico"},
                new User{Id = 5, Name = "Layla", Age = 23, Nation = "China"},
                new User{Id = 6, Name = "Fin", Age = 30, Nation = "America"},
                new User{Id = 7, Name = "Cassidy", Age = 41, Nation = "America"},
                new User{Id = 8, Name = "Alex", Age = 11, Nation = "England"},
            };
        }


        public bool IsUserBelow20(int id)
        {
            return ListUser.Any(x => x.Age < 20 && x.Id == id);
        }

        public List<User> GetUsersByName(string name)
        {
            var users = ListUser.Where(x => x.Name == name);
            if (users != null)
            {
                return users.ToList();
            }
            return new List<User>();
        }

        public bool AddUser(User user)
        {
            // Add fail when user is null or user id exist in list user
            if (user == null)
            {
                return false;
            }
            else if (ListUser.Any(x => x.Id == user.Id))
            {
                return false;
            }

            // Add new user
            ListUser.Add(user);

            return true;
        }

        public bool DoSomething(string value)
        {
            throw new NotImplementedException();
        }

        #region Working with dbContext
        //public List<User> GetUsersByName(string name)
        //{
        //    var users = _contest.Users.Where(x => x.Name == name);
        //    if (users != null)
        //    {
        //        return users.ToList();
        //    }
        //    return new List<User>();
        //}

        //public bool AddUser(User user)
        //{
        //    // Add fail when user is null or user id exist in list user
        //    if (user == null)
        //    {
        //        return false;
        //    }
        //    else if(_contest.Users.Any(x => x.Id == user.Id))
        //    {
        //        return false;
        //    }

        //    // Add new user
        //    _contest.Users.Add(user);

        //    _contest.SaveChanges();

        //    return true;
        //}
        #endregion
    }
}
