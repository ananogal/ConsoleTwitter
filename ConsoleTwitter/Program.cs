using ConsoleTwitter.Actions;
using ConsoleTwitter.Domain;
using ConsoleTwitter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTwitter
{
    class Program
    {
        static ConsoleWriter console;
        public static void Main(string[] args)
        {
            console = new ConsoleWriter();
            WriteInstructions();
            WaitForCommand();
        }

        private static void WriteInstructions()
        {
            console.WriteWelcomeMessage();
        }

        private static void WaitForCommand()
        {
            var usersRepository = new UsersRepository();
            var postsRepository = new PostsRepository();
            var commandFactory = new CommandFactory();
            var console = new ConsoleWriter();
            do
            {
                console.WriteMessage("Please enter a command:");
                var stringCommand = Console.ReadLine();
                var createUserInput = new UserInputParser(stringCommand);
                var executeCommand = new Command(createUserInput, usersRepository,
                                                        postsRepository, commandFactory, console);
                executeCommand.Execute();
            } while (true);
        }
    }
}
