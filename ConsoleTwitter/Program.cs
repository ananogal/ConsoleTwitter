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
    public class Program
    {
        static WriteToConsole console;
        public static void Main(string[] args)
        {
            console = new WriteToConsole();
            WriteInstructions();
            WaitForCommand();
        }

        private static void WriteInstructions()
        {
            console.WriteWelcomeMessage();
        }

        private static void WaitForCommand()
        {
            var posts = new List<Post>();
            var users = new List<User>();
            var usersRepository = new UsersRepository(users);
            var postsRepository = new PostsRepository(posts);
            var commandFactory = new CommandFactory();
            var console = new WriteToConsole();
            do
            {
                console.Writeline("Please enter a command:");
                var stringCommand = Console.ReadLine();
                var createUserInput = new UserInputFactory(stringCommand);
                var executeCommand = new ExecuteCommand(createUserInput, usersRepository,
                                                        postsRepository, commandFactory, console);
                executeCommand.Execute();
            } while (true);
        }
    }
}
