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
    public class CreateUserInputFromPostCommandTests
    {
        [Test]
        public void ItShouldCreateAUserInputFromACommandString()
        {
            var stringCommand = "Ana -> Hello!";
            var factory = new CreateUserInputFromPostCommand(stringCommand);
            var userInput = factory.Create();

            userInput.Should().NotBeNull();
        }
    }
}
