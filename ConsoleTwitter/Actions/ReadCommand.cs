using ConsoleTwitter.Domain;
using ConsoleTwitter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Actions
{
    public class ReadCommand : ICommand
    {
        private UserInput userInput;
        private UsersRepository users;
        private PostsRepository posts;
        public ReadCommand(UserInput userInput, UsersRepository users, PostsRepository posts)
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
