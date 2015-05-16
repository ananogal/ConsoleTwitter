using ConsoleTwitter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Domain
{
    public class UserInputParser
    {
        private string stringCommand;
        const string FOLLOWS = "follows";
        const string WALL = "wall";
        
        public UserInputParser(string stringCommand)
        {
            this.stringCommand = stringCommand.Trim();
        }
        
        public UserInput Parse()
        {
            var separator = new char[] { ' ' };
            var tokenizedUserInput = this.stringCommand.Split(
                                        separator, 
                                        StringSplitOptions.RemoveEmptyEntries);

            return BuildUserInput(tokenizedUserInput); 
        }

        private UserInput BuildUserInput(string[] tokenizedUserInput)
        {
            UserInput userInput;

            if (tokenizedUserInput.Count() == 1)
            {
                userInput = new UserInput(this.stringCommand, CommandType.Read);
            }
            else
            {
                var username = tokenizedUserInput.First().Trim();
                var command = tokenizedUserInput.Skip(1).First().Trim();
                var message = string.Join(" ", tokenizedUserInput.Skip(2));
                var type = ComposeCommandType(command);

                userInput = new UserInput(username, command, message, type);
            }

            return userInput;
        }

        private CommandType ComposeCommandType(string command)
        {
            var type = CommandType.Post;

            if (command.Equals(FOLLOWS, StringComparison.OrdinalIgnoreCase))
            {
                type = CommandType.Follow;
            }

            if (command.Equals(WALL, StringComparison.OrdinalIgnoreCase))
            {
                type = CommandType.Wall;
            }

            return type;
        }
    }
}
