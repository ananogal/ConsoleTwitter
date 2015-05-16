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
    public class Command
    {
        private UsersRepository usersRepository;
        private UserInputParser createUserInput;
        private PostsRepository postsRepository;
        private CommandFactory commandFactory;
        private ConsoleWriter console;

        public Command(UserInputParser userInputParser, UsersRepository users, 
                                PostsRepository posts, CommandFactory commandFactory,
                                ConsoleWriter console)
        {
            this.createUserInput = userInputParser;
            this.usersRepository = users;
            this.postsRepository = posts;
            this.commandFactory = commandFactory;
            this.console = console;
        }

        public virtual void Execute()
        {
            var userInput = createUserInput.Parse();
            var command = commandFactory.Create(userInput, usersRepository, postsRepository);
            var latestPosts = command.Execute();
            if (latestPosts != null)
            {
                if (userInput.CommandType == CommandType.Read) {
                    ShowPosts(latestPosts);
                } 
                else 
                {
                    ShowWall(latestPosts);
                }
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
