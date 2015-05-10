using ConsoleTwitter.Actions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ConsoleTwitter.Domain;

namespace ConsoleTwitterTests.Unit.Actions
{
    [TestFixture]
    public class CreateUserInputTests
    {
        [Test]
        public void ItShouldCreateAUserInputFromAPostCommand()
        {
            var input = "Ana -> Hello";
            var createUserInput = new UserInputFactory(input);
            var userInput = createUserInput.Create();

            userInput.CommandType.Should().Be(CommandType.Post);
        }

        [Test]
        public void ItShouldCreateAUserInputFromAReadCommand()
        {
            var input = "Ana";
            var createUserInput = new UserInputFactory(input);
            var userInput = createUserInput.Create();

            userInput.CommandType.Should().Be(CommandType.Read);
        }

        [Test]
        public void ItShouldCreateAUserInputFromAFollowCommand()
        {
            var input = "Ana follows Pedro";
            var createUserInput = new UserInputFactory(input);
            var userInput = createUserInput.Create();

            userInput.CommandType.Should().Be(CommandType.Follow);
        }
    }
}
