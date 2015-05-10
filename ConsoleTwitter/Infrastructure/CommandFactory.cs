using ConsoleTwitter.Actions;
using ConsoleTwitter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Infrastructure
{
    public class CommandFactory
    {
        public IExecuteCommand Create(UserInput userInput, UsersRepository usersRepository, PostsRepository postsRepository)
        {
            switch (userInput.CommandType)
            {
                case CommandType.Post:
                    {
                        return new ExecutePostCommand(userInput, usersRepository, postsRepository);
                    }
                case CommandType.Read:
                    {
                        return new ExecuteReadCommand(userInput, usersRepository, postsRepository);
                    }
                case CommandType.Follow:
                    return new ExecuteFollowCommand(userInput, usersRepository);
                case CommandType.Wall:
                    return null;
                default:
                    return null;
            }
        }
    }
}
