using Moq;
using MyUnitTestProject.Controllers;
using MyUnitTestProject.Models;
using MyUnitTestProject.Service;
using MyUnitTestProject1.Theory;

namespace MyUnitTestProject1
{
    public class UserServiceTest
    {
        private Mock<IUserService> mockUserService = new Mock<IUserService>();
        //private UserService _userService { get; set; }

        public UserServiceTest()
        {
            //_userService = new UserService();
        }

        //[Fact]
        //public void IsUsersBelow20False()
        //{
        //    int userId = 1;
        //    var result = _userService.IsUserBelow20(userId);
        //    Assert.True(result);
        //}

        //[Fact]
        //public void IsUsersBelow20True()
        //{
        //    int userId = 2;
        //    var result = _userService.IsUserBelow20(userId);
        //    Assert.True(result);
        //}

        [Theory]
        [InlineData("Hung")]
        [InlineData("Alex")]
        [InlineData("Lai")]
        public void GetUsersByNameTest(string name)
        {
            var users = new List<User> { new User { Id = 1, Name = "Hung", Age = 24, Nation = "VietNam" } };
            mockUserService.Setup(p => p.GetUsersByName(name));
            UserController userController = new UserController(mockUserService.Object);
            var result = userController.GetUserByName(name);
            Assert.NotNull(result);
        }

        //[Theory]
        //[ClassData(typeof(UserTheoryData))]
        //public void AddUserWithTestData(User user)
        //{
        //    var result = _userService.AddUser(user);

        //    Assert.True(result);
        //}
    }
}