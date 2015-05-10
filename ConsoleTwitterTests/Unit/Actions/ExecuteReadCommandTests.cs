using ConsoleTwitter.Actions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ConsoleTwitter.Infrastructure;
using NSubstitute;
using ConsoleTwitter.Domain;

namespace ConsoleTwitterTests.Unit.Actions
{
    [TestFixture]
    public class ExecuteReadCommandTests
    {
        string input;
        UserInput userInput;
        UsersRepository users;
        PostsRepository posts;
        ExecuteReadCommand command;

        [SetUp]
        public void BeforeEach()
        {
            input = "Ana   ";
            var createUserInput = new UserInputFactory(input);
            userInput = createUserInput.Create();
            users = Substitute.For<UsersRepository>(new List<User>());
            posts = Substitute.For<PostsRepository>(new List<Post>());
            command = new ExecuteReadCommand(userInput, users, posts);
        }


        [Test]
        public void ItShouldColaborateWithUsersRepositoryToGetTheUser()
        {
            command.Execute();

            users.Received().GetUser(Arg.Any<string>());
        }

        [Test]
        public void ItShouldColaborateWithPostsRepositoryToGetPosts()
        {
            command.Execute();

            posts.Received().GetAllByUser(Arg.Any<User>());
        }
    }
}
