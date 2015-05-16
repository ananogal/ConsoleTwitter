using ConsoleTwitter.Domain;
using ConsoleTwitter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTwitter.Actions
{
    public class FollowCommand : ICommand
    {
        private UserInput userInput;
        private UsersRepository users;

        public FollowCommand(UserInput userInput, UsersRepository users)
        {
            this.userInput = userInput;
            this.users = users;
        }

        public List<Post> Execute()
        {
            var user = users.GetUser(userInput.Username);
            var userToFollow = users.GetUser(userInput.Action);
            users.FollowUser(user, userToFollow);

            return new List<Post>();
        }
    }
}
