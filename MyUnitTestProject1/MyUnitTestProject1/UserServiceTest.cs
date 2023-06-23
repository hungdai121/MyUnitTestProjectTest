using MyUnitTestProject.Models;
using MyUnitTestProject.Service;
using MyUnitTestProject1.Theory;

namespace MyUnitTestProject1
{
    public class UserServiceTest
    {
        private UserService _userService { get; set; }

        public UserServiceTest()
        {
            _userService = new UserService();
        }

        [Fact]
        public void IsUsersBelow20False()
        {
            int userId = 1;
            var result = _userService.IsUserBelow20(userId);
            Assert.True(result);
        }

        [Fact]
        public void IsUsersBelow20True()
        {
            int userId = 2;
            var result = _userService.IsUserBelow20(userId);
            Assert.True(result);
        }

        [Theory]
        [InlineData("Hung")]
        [InlineData("Alex")]
        [InlineData("Joan")]
        public void GetUsersByNameTest(string name)
        {
            var result = _userService.GetUsersByName(name);
            Assert.NotEmpty(result);
        }

        [Theory]
        [ClassData(typeof(UserTheoryData))]
        public void AddUserWithTestData(User user)
        {
            var result = _userService.AddUser(user);

            Assert.True(result);
        }
    }
}