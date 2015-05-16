using ConsoleTwitter.Actions;
using ConsoleTwitter.Domain;
using ConsoleTwitter.Helpers;
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
        private ConsoleWriter console = new ConsoleWriter();
        private UsersRepository usersRepository = new UsersRepository();
        private PostsRepository postsRepository = new PostsRepository();
        private CommandFactory commandFactory = new CommandFactory();
        private UserInputParser userInputParser = new UserInputParser();

        public Program(UserInputParser userInputParser, UsersRepository usersRepository, 
                        PostsRepository postsRepository, CommandFactory commandFactory,
                        ConsoleWriter console)
        {
            this.console = console;
            this.commandFactory = commandFactory;
            this.postsRepository = postsRepository;
            this.userInputParser = userInputParser;
            this.usersRepository = usersRepository;
        }

        public Program()
        {
        }

        public static void Main(string[] args)
        {
            var program = new Program();
            program.WriteInstructions();
            program.WaitForCommand();
        }

        private void WriteInstructions()
        {
            console.WriteWelcomeMessage();
        }

        public void WaitForCommand()
        {
            do
            {
                console.WriteMessage("Please enter a command:");
                var stringCommand = Console.ReadLine();
                var userInput = userInputParser.Parse(stringCommand);

                Execute(userInput);

            } while (true);
        }

        public virtual void Execute(UserInput userInput)
        {
            var command = commandFactory.Create(userInput, usersRepository, postsRepository);
            var latestPosts = command.Execute();

            if (userInput.CommandType == CommandType.Read)
            {
                ShowPosts(latestPosts);
            }

            if (userInput.CommandType == CommandType.Wall)
            {
                ShowWall(latestPosts);
            }
        }

        private void ShowPosts(List<Post> latestPosts)
        {
            foreach (var post in latestPosts)
            {
                var elapsedTime = FormatTime.Format(post.PublishedDate);
                console.WriteMessage(post.Message + elapsedTime);
            }
        }

        private void ShowWall(List<Post> latestPosts)
        {
            foreach (var post in latestPosts)
            {
                var elapsedTime = FormatTime.Format(post.PublishedDate);
                console.WriteMessage(post.User.Username + " - " + post.Message + elapsedTime);
            }
        }
    }
}
