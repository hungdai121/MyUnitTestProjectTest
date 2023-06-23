﻿using MyUnitTestProject.Models;

namespace MyUnitTestProject.Service
{
    public class UserService
    {
        private List<User> _users { get; set; }

        public UserService()
        {
            _users = new List<User>
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
            return _users.Any(x => x.Age < 20 && x.Id == id);
        }

        public List<User> GetUsersByName(string name)
        {
            var users = _users.Where(x => x.Name == name);
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
            else if(_users.Any(x => x.Id == user.Id))
            {
                return false;
            }

            // Add new user
            _users.Add(user);

            return true;
        }
    }
}
