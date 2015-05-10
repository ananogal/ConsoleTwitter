using ConsoleTwitter.Domain;
using ConsoleTwitter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Actions
{
    public class ExecuteReadCommand : IExecuteCommand
    {
        private UserInput userInput;
        private UsersRepository users;
        private PostsRepository posts;
        public ExecuteReadCommand(UserInput userInput, PostsRepository posts, UsersRepository users)
        {
            this.userInput = userInput;
            this.posts = posts;
            this.users = users; 
        }

        public List<Post> Execute()
        {
            var user = users.GetUser(userInput.Username);
            return posts.GetAllByUser(user);
        }
    }
}
