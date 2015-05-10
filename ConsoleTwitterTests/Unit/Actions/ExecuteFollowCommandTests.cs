using ConsoleTwitter.Actions;
using ConsoleTwitter.Domain;
using ConsoleTwitter.Infrastructure;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTwitterTests.Unit.Actions
{
    [TestFixture]
    public class ExecuteFollowCommandTests
    {
        string input;
        UserInput userInput;
        UsersRepository users;
        ExecuteFollowCommand command;

        [SetUp]
        public void BeforeEach()
        {
            input = "Ana follows Pedro";
            var createUserInput = new UserInputFactory(input);
            userInput = createUserInput.Create();
            users = Substitute.For<UsersRepository>(new List<User>());
            command = new ExecuteFollowCommand(userInput, users);
        }

        [Test]
        public void ColaboratesWithUsersRepositoryToGetTheUser()
        {
            command.Execute();

            users.Received().GetUser(userInput.Username);
        }

        [Test]
        public void ColaboratesWithUsersRepositoryToGetUserToFollow()
        {
            command.Execute();

            users.Received().GetUser(userInput.Action);
        }

        [Test]
        public void ColaboratesWithUsersRepositoryToFollowTheUser()
        {
            command.Execute();

            users.Received().FollowUser(Arg.Any<User>(), Arg.Any<User>());
        }
    }
}
