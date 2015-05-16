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
        FollowCommand command;

        [SetUp]
        public void BeforeEach()
        {
            input = "Ana follows Pedro";
            userInput = new UserInputParser().Parse(input);
            users = Substitute.For<UsersRepository>();
            command = new FollowCommand(userInput, users);
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
            var user = users.GetUser("Ana");
            var followee = users.GetUser("Pedro");
            command = new FollowCommand(userInput, users);
            command.Execute();


            users.Received().FollowUser(user, followee);
        }
    }
}
