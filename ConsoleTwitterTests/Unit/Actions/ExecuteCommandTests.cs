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
    public class ExecuteCommandTests
    {
        UsersRepository users;
        PostsRepository posts;
        CommandFactory commandFactory;

        [SetUp]
        public void BeforeEach()
        {
            users = Substitute.For<UsersRepository>(new List<User>());
            posts = Substitute.For<PostsRepository>(new List<Post>());
            commandFactory = Substitute.For<CommandFactory>();
        }
        
        [Test]
        public void ItShouldColaborateWithCreateUserInputToCreateAUserInput()
        {
            string userImput = "Ana   ";
            var userInputFactory = Substitute.For<CreateUserInput>(userImput);
            var command = new ExecuteCommand(userInputFactory, users, posts, commandFactory);

            command.Execute();

            userInputFactory.Received().Create();
        }

        [Test]
        public void ItShouldColaborateWithCommandFactoryToCreateAPostCommand()
        {
            string userImput = "Ana -> Hello!";
            var userInputFactory = Substitute.For<CreateUserInput>(userImput);
            var command = new ExecuteCommand(userInputFactory, users, posts, commandFactory);

            command.Execute();

            commandFactory.Received().Create(Arg.Any<UserInput>(), Arg.Any<UsersRepository>(), Arg.Any<PostsRepository>());
        }
    }
}
