using ConsoleTwitter;
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
    public class ProgramTests
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
            string userInput = "Ana   ";
            var userInputFactory = Substitute.For<UserInputParser>();
            var program = new Program(userInputFactory, users, posts, commandFactory, console);

            program.WaitForCommand();

            userInputFactory.Received().Parse(userInput);
        }

        [Test]
        public void ItShouldColaborateWithCommandFactoryToCreateACommand()
        {
            string userImput = "Ana -> Hello!";
            var userInputParser = Substitute.For<UserInputParser>();
            var program = new Program(userInputParser, users, posts, commandFactory, console);

            program.Execute(userInputParser.Parse(userImput));

            commandFactory.Received().Create(Arg.Any<UserInput>(), Arg.Any<UsersRepository>(), Arg.Any<PostsRepository>());
        }

        [Test]
        public void ColaboratesWithConsoleToWriteResults()
        {
            string userInput = "Ana -> Hello!";
            var userInputParser = Substitute.For<UserInputParser>();
            var program = new Program(userInputParser, users, posts, commandFactory, console);
            program.Execute(userInputParser.Parse(userInput));
            
            userInput = "Ana";
            userInputParser= Substitute.For<UserInputParser>();
            program = new Program(userInputParser, users, posts, commandFactory, console);
            program.Execute(userInputParser.Parse(userInput));

            console.Received().WriteMessage(Arg.Any<string>());
        }
    }
}
