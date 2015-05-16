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
            var factory = new UserInputParser(input);
			var userInput = factory.Parse();

            userInput.CommandType.Should().Be(CommandType.Post);
        }

        [Test]
        public void ItShouldCreateAUserInputFromAReadCommand()
        {
            var input = "Ana";
			var factory = new UserInputParser(input);
			var userInput = factory.Parse();

            userInput.CommandType.Should().Be(CommandType.Read);
        }

        [Test]
        public void ItShouldCreateAUserInputFromAFollowCommand()
        {
            var input = "Ana follows Pedro";
			var factory = new UserInputParser(input);
			var userInput = factory.Parse();

            userInput.CommandType.Should().Be(CommandType.Follow);
        }

		[Test]
		public void ItShouldCreateAUserInputFromAWallCommand()
		{
			var input = "Ana wall";
			var factory = new UserInputParser(input);
			var userInput = factory.Parse();

			userInput.CommandType.Should().Be(CommandType.Wall);
		}
    }
}
