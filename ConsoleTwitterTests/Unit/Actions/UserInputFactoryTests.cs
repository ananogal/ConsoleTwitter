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
    public class UserInputFactoryTests
    {
        [Test]
        public void ItShouldCreateAUserInputFromAPostCommand()
        {
            var input = "Ana -> Hello";
			var userInput = new UserInputParser().Parse(input);

            userInput.CommandType.Should().Be(CommandType.Post);
        }

        [Test]
        public void ItShouldCreateAUserInputFromAReadCommand()
        {
            var input = "Ana";
            var userInput = new UserInputParser().Parse(input);

            userInput.CommandType.Should().Be(CommandType.Read);
        }

        [Test]
        public void ItShouldCreateAUserInputFromAFollowCommand()
        {
            var input = "Ana follows Pedro";
            var userInput = new UserInputParser().Parse(input);

            userInput.CommandType.Should().Be(CommandType.Follow);
        }

		[Test]
		public void ItShouldCreateAUserInputFromAWallCommand()
		{
			var input = "Ana wall";
            var userInput = new UserInputParser().Parse(input);

			userInput.CommandType.Should().Be(CommandType.Wall);
		}
    }
}
