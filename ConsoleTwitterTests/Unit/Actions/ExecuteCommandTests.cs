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
        ConsoleWriter console;

        [SetUp]
        public void BeforeEach()
        {
            users = new UsersRepository();
            posts = new PostsRepository();
            commandFactory = Substitute.For<CommandFactory>();
            console = Substitute.For<ConsoleWriter>();
        }
        
        [Test]
        public void ItShouldColaborateWithCreateUserInputToCreateAUserInput()
        {
            string userImput = "Ana   ";
            var userInputFactory = Substitute.For<UserInputParser>(userImput);
            var command = new Command(userInputFactory, users, posts, commandFactory, console);

            command.Execute();

            userInputFactory.Received().Parse();
        }

        [Test]
        public void ItShouldColaborateWithCommandFactoryToCreateACommand()
        {
            string userImput = "Ana -> Hello!";
            var userInputFactory = Substitute.For<UserInputParser>(userImput);
            var command = new Command(userInputFactory, users, posts, commandFactory, console);

            command.Execute();

            commandFactory.Received().Create(Arg.Any<UserInput>(), Arg.Any<UsersRepository>(), Arg.Any<PostsRepository>());
        }

        [Test]
        public void ColaboratesWithConsoleToWriteResults()
        {
            string userInput = "Ana -> Hello!";
            var userInputFactory = Substitute.For<UserInputParser>(userInput);
            var command = new Command(userInputFactory, users, posts, commandFactory, console);
            command.Execute();
            
            userInput = "Ana";
            var userInputFactory2 = Substitute.For<UserInputParser>(userInput);
            command = new Command(userInputFactory2, users, posts, commandFactory, console);
            command.Execute();

            console.Received().WriteMessage(Arg.Any<string>());
        }
    }
}
