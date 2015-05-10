using ConsoleTwitter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Actions
{
    public class UserInputFactory
    {
        private string stringCommand;
        const string FOLLOWS = "follows";

        public UserInputFactory(string stringCommand)
        {
            this.stringCommand = stringCommand.Trim();
        }


        public UserInput Create()
        {
            var separator = new char[] { ' ' };
            var userInputArray = this.stringCommand.Split(separator, 
                                    StringSplitOptions.RemoveEmptyEntries);
            UserInput userInput;
            if (userInputArray.Count() == 1)
            {
                userInput = new UserInput(this.stringCommand, null, null, CommandType.Read);
            }
            else
            {
                var message = "";
                for (int i = 2; i < userInputArray.Count(); i++)
                {
                    message += userInputArray[i] + " ";
                }
                var username = userInputArray[0].Trim();
                var command = userInputArray[1].Trim();
                CommandType type = CommandType.Post;
                if (command.Equals(FOLLOWS, StringComparison.OrdinalIgnoreCase))
                    type = CommandType.Follow;
                userInput = new UserInput(username, command, message, type);
            }
            return userInput; 
        }
    }
}
