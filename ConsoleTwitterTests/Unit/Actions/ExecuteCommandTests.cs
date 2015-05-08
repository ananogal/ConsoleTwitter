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
        string userImput;
        CreateUserInputFromPostCommand userInputFactory;
        UsersRepository users;
        PostsRepository posts;

        [SetUp]
        public void BeforeEach()
        {
            userImput = "Ana -> Hello!";
            userInputFactory = Substitute.For<CreateUserInputFromPostCommand>(userImput);
            users = Substitute.For<UsersRepository>();
            posts = Substitute.For<PostsRepository>();
        }

        [Test]
        public void ItShouldColaborateWithCreateUserInputFromPostCommandToCreateAUserInput()
        {
             var command = new ExecutePostCommand(userInputFactory, users, posts);

            command.Execute();
            userInputFactory.Received().Create();
        }

        [Test]
        public void ItShouldColaborateWithUsersRepositoryAndGetTheUser()
        {
            var command = new ExecutePostCommand(userInputFactory, users, posts);

            command.Execute();

            users.Received().GetUser("Ana");
        }

        [Test]
        public void ItShouldColaborateWithPostRepositoryToCreateAPost()
        {
            var command = new ExecutePostCommand(userInputFactory, users, posts);

            command.Execute();

            posts.Received().Create(Arg.Any<User>(), Arg.Any<string>());
        }
    }
}
