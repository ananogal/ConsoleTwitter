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
        WriteToConsole console;

        [SetUp]
        public void BeforeEach()
        {
            users = Substitute.For<UsersRepository>(new List<User>());
            posts = Substitute.For<PostsRepository>(new List<Post>());
            commandFactory = Substitute.For<CommandFactory>();
            console = Substitute.For<WriteToConsole>();
        }
        
        [Test]
        public void ItShouldColaborateWithCreateUserInputToCreateAUserInput()
        {
            string userImput = "Ana   ";
            var userInputFactory = Substitute.For<UserInputFactory>(userImput);
            var command = new ExecuteCommand(userInputFactory, users, posts, commandFactory, console);

            command.Execute();

            userInputFactory.Received().Create();
        }

        [Test]
        public void ItShouldColaborateWithCommandFactoryToCreateACommand()
        {
            string userImput = "Ana -> Hello!";
            var userInputFactory = Substitute.For<UserInputFactory>(userImput);
            var command = new ExecuteCommand(userInputFactory, users, posts, commandFactory, console);

            command.Execute();

            commandFactory.Received().Create(Arg.Any<UserInput>(), Arg.Any<UsersRepository>(), Arg.Any<PostsRepository>());
        }

        [Test]
        public void ColaboratesWithConsoleToWriteResults()
        {
            string userInput = "Ana -> Hello!";
            var userInputFactory = Substitute.For<UserInputFactory>(userInput);
            var command = new ExecuteCommand(userInputFactory, users, posts, commandFactory, console);
            command.Execute();
            
            userInput = "Ana";
            var userInputFactory2 = Substitute.For<UserInputFactory>(userInput);
            command = new ExecuteCommand(userInputFactory2, users, posts, commandFactory, console);
            command.Execute();

            console.Received().Writeline(Arg.Any<string>());
        }
    }
}
