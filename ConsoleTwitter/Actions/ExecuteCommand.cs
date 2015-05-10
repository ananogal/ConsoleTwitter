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
        private CreateUserInput createUserInput;
        private PostsRepository postsRepository;
        private CommandFactory commandFactory;

        public ExecuteCommand(CreateUserInput userInputFactory, UsersRepository users, PostsRepository posts, CommandFactory commandFactory)
        {
            this.createUserInput = userInputFactory;
            this.usersRepository = users;
            this.postsRepository = posts;
            this.commandFactory = commandFactory;
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
                    Console.WriteLine(post.Message + elapsedTime);
                }
            }
        }
    }
}
