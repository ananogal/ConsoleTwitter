using ConsoleTwitter.Actions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace ConsoleTwitterTests.Unit.Actions
{
    [TestFixture]
    public class CreateUserInputTests
    {
        [Test]
        public void ItShouldCreateAUserInputFromAPostCommand()
        {
            var input = "Ana -> Hello";
            var createUserInput = new CreateUserInput(input);
            var userInput = createUserInput.Create();

            userInput.Should().NotBeNull();
        }

        [Test]
        public void ItShouldCreateAUserInputFromAReadCommand()
        {
            var input = "Ana";
            var createUserInput = new CreateUserInput(input);
            var userInput = createUserInput.Create();

            userInput.Should().NotBeNull();
        }
    }
}
