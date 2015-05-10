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
				return new ExecuteWallCommand(userInput, usersRepository, postsRepository);
                default:
                    return null;
            }
        }
    }
}
