using Microsoft.AspNetCore.Mvc;
using Moq;
using MyUnitTestProject.Controllers;
using MyUnitTestProject.Models;
using MyUnitTestProject.Service;
using MyUnitTestProject1.Theory;
using FluentAssertions;
using FluentAssertions.Execution;

namespace MyUnitTestProject1
{
    public class SimpleFluentAssertionTest
    {
        private UserService _userService { get; set; }

        public SimpleFluentAssertionTest()
        {
            _userService = new UserService();
        }

        // Nomarl Assert Class
        [Fact]
        public void StringTest()
        {
            string result = "Hello World";

            Assert.StartsWith("Hello", result);

            Assert.EndsWith("World", result);
        }

        // Using Fluent Assertion
        [Fact]
        public void StringFluentAssertionTest()
        {
            string result = "Hello World";

            // FluentAssertion Using extension method to combine all the test expected in 1 line code
            result.Should().StartWith("Hello").And.EndWith("World");

            // Throw Failling exception with custom message
            result.Should().BeLowerCased($"result should be {result.ToLower()}");
        }


        // Using Fluent Assertion
        [Fact]
        public void UserFluentAssertionTest()
        {

            var result = _userService.GetUsersByName("Alex");

            using (new AssertionScope())
            {
                result.Should().HaveCountGreaterThan(2);

                result.FirstOrDefault()?.Name.Should().Be("Hung");
            }
            
        }

    }
}