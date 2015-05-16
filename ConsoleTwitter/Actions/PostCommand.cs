using ConsoleTwitter.Domain;
using ConsoleTwitter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Actions
{
    public class PostCommand : ICommand
    {
        private UserInput userInput;
        private UsersRepository usersRepository;
        private PostsRepository postsRepository;

        public PostCommand(UserInput userInput, UsersRepository usersRepository, PostsRepository postsRepository)
        {
            this.userInput= userInput;
            this.usersRepository = usersRepository;
            this.postsRepository = postsRepository;
        }

        public List<Post> Execute()
        {
            var user = usersRepository.GetUser(userInput.Username);
            postsRepository.Create(user, userInput.Action);
            return null;
        }
    }
}
