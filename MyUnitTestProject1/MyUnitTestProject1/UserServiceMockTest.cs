using Microsoft.AspNetCore.Mvc;
using Moq;
using MyUnitTestProject.Controllers;
using MyUnitTestProject.Models;
using MyUnitTestProject.Service;
using MyUnitTestProject1.Theory;

namespace MyUnitTestProject1
{
    public class UserServiceMockTest
    {
        private Mock<IUserService> mockUserService = new Mock<IUserService>();

        public UserServiceMockTest()
        {
        }

        [Fact]
        public void DoSomethingTest()
        {
            // Setup method DoSomething and return true
            mockUserService.Setup(p => p.DoSomething("Dummy input")).Returns(true);

            IUserService userService = mockUserService.Object;

            var result = userService.DoSomething("Dummy input");

            // Test success when result is true
            Assert.True(result);
        }

        [Fact]
        public void DoSomethingInvalidTest()
        {
            // Setup method DoSomething and throw exception
            mockUserService.Setup(p => p.DoSomething("Dummy input")).Throws<InvalidDataException>();

            IUserService userService = mockUserService.Object;

            userService.DoSomething("Dummy input");

            Assert.True(true);
        }

        [Fact]
        public void GetUsersTest()
        {
            var users = new List<User>
            {
                new User { Id = 1, Name = "Hung", Age = 24, Nation = "VietNam" },
                new User {Id = 2, Name = "Don", Age = 36, Nation = "Italy"},
                new User {Id = 3, Name = "Xiao", Age = 44, Nation = "China"},
            };

            // Setup property ListUser
            mockUserService.SetupSet(p => p.ListUser = users);

            UserController userController = new UserController(mockUserService.Object);
            var result = userController.GetUsers();

            // Test success when result is not null
            Assert.NotNull(result);
        }

        [Fact]
        public void GetSetUsersTest()
        {
            var users = new List<User>
            {
                new User { Id = 1, Name = "Hung", Age = 24, Nation = "VietNam" },
                new User {Id = 2, Name = "Don", Age = 36, Nation = "Italy"},
                new User {Id = 3, Name = "Xiao", Age = 44, Nation = "China"},
            };

            // start "tracking" sets/gets to ListUser property
            mockUserService.SetupProperty(p => p.ListUser);
            var userService = mockUserService.Object;
            userService.ListUser = users;

            // Test success when List user lenght equal 3
            Assert.True(userService.ListUser.Count == 3);

            //Test success when List user add 1 user and the list lenght equal 4
            userService.ListUser.Add(new User { Id = 4, Name = "Mario", Age = 35, Nation = "Italy" });
            Assert.True(userService.ListUser.Count == 4);
        }

        [Theory]
        [InlineData("Hung")]
        [InlineData("Alex")]
        [InlineData("Lai")]
        public void GetUsersByNameMatchingArgumentsTest(string name)
        {
            var users = new List<User>
            {
                new User { Id = 1, Name = "Hung", Age = 24, Nation = "VietNam" }
            };

            // Using Moq.It to Matching Arguments
            // Setup method retrun list User when input = "Hung"
            mockUserService.Setup(p => p.GetUsersByName(It.Is<string>(x => x == "Hung"))).Returns(users);

            UserController userController = new UserController(mockUserService.Object);
            var result = userController.GetUserByName(name);

            // Test success when result is not null
            Assert.NotNull(result);
        }
    }
}