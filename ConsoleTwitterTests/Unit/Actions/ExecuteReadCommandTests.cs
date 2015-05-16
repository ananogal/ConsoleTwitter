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
        ReadCommand command;

        [SetUp]
        public void BeforeEach()
        {
            input = "Ana   ";
            userInput = new UserInputParser().Parse(input);
            users = Substitute.For<UsersRepository>();
            posts = Substitute.For<PostsRepository>();
            command = new ReadCommand(userInput, users, posts);
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
