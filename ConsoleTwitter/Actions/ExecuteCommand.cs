using ConsoleTwitter.Helpers;
using ConsoleTwitter.Domain;
using ConsoleTwitter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTwitter.Actions
{
    public class ExecuteCommand
    {
        private UsersRepository usersRepository;
        private UserInputFactory createUserInput;
        private PostsRepository postsRepository;
        private CommandFactory commandFactory;
        private WriteToConsole console;

        public ExecuteCommand(UserInputFactory userInputFactory, UsersRepository users, 
                                PostsRepository posts, CommandFactory commandFactory,
                                WriteToConsole console)
        {
            this.createUserInput = userInputFactory;
            this.usersRepository = users;
            this.postsRepository = posts;
            this.commandFactory = commandFactory;
            this.console = console;
        }

        public virtual void Execute()
        {
            var userInput = createUserInput.Create();
            var command = commandFactory.Create(userInput, usersRepository, postsRepository);
            var latestPosts = command.Execute();
            if (latestPosts != null)
            {
                foreach (var post in latestPosts)
                {
                    var elapsedTime = FormatTime.Format(post.PublishedDate);
                    console.Writeline(post.Message + elapsedTime);
                }
            }
        }
    }
}
