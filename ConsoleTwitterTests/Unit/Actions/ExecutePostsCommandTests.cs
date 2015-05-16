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
    public class ExecutePostsCommandTests
    {
        string input;
        UserInput userInput;
        UsersRepository users;
        PostsRepository posts;
        PostCommand command;

        [SetUp]
        public void BeforeEach()
        {
            input = "Ana -> Hello!";
            var createUserInput = new UserInputParser(input);
            userInput = createUserInput.Parse();
            users = Substitute.For<UsersRepository>();
            posts = Substitute.For<PostsRepository>();
            command = new PostCommand(userInput, users, posts);
        }

        [Test]
        public void ItShouldColaborateWithUsersRepositoryAndGetTheUser()
        {
            command.Execute();

            users.Received().GetUser(Arg.Any<string>());
        }

        [Test]
        public void ItShouldColaborateWithPostRepositoryToCreateAPost()
        {
            command.Execute();
            posts.Received().Create(Arg.Any<User>(), Arg.Any<string>());
        }
    }
}
