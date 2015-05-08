using ConsoleTwitter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Actions
{
    public class ExecutePostCommand
    {
        private UsersRepository users;
        private CreateUserInputFromPostCommand factory;
        private PostsRepository posts;

        public ExecutePostCommand(CreateUserInputFromPostCommand factory, UsersRepository users, PostsRepository posts)
        {
            // TODO: Complete member initialization
            this.factory = factory;
            this.users = users;
            this.posts = posts;
        }


        public void Execute()
        {
            var userInput = factory.Create();
            var user = users.GetUser(userInput.Username);

        }
    }
}
