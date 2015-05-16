using ConsoleTwitter.Actions;
using ConsoleTwitter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTwitter.Infrastructure;

namespace ConsoleTwitter.Actions
{
    public class CommandFactory
    {
        public ICommand Create(UserInput userInput, UsersRepository usersRepository, PostsRepository postsRepository)
        {
            switch (userInput.CommandType)
            {
                case CommandType.Post:
                    {
                        return new PostCommand(userInput, usersRepository, postsRepository);
                    }
                case CommandType.Read:
                    {
                        return new ReadCommand(userInput, usersRepository, postsRepository);
                    }
                case CommandType.Follow:
                    { 
                        return new FollowCommand(userInput, usersRepository); 
                    }
                case CommandType.Wall:
                    {
                        return new WallCommand(userInput, usersRepository, postsRepository);
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
