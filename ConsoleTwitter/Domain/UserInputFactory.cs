using ConsoleTwitter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Domain
{
    public class UserInputFactory
    {
        private string stringCommand;
        const string FOLLOWS = "follows";
		const string WALL = "wall";

        public UserInputFactory(string stringCommand)
        {
            this.stringCommand = stringCommand.Trim();
        }


        public UserInput Create()
        {
            var separator = new char[] { ' ' };
            var userInputArray = this.stringCommand.Split(separator, 
                                    StringSplitOptions.RemoveEmptyEntries);
			return buildUserInput (userInputArray); 
        }

		private UserInput buildUserInput(string[] strArray)
		{
			UserInput userInput;
			if (strArray.Count() == 1)
			{
				userInput = new UserInput(this.stringCommand, null, null, CommandType.Read);
			}
			else
			{
				var message = composeMessage(strArray);
				var username = strArray[0].Trim();
				var command = strArray[1].Trim();
				CommandType type = composeCommandType(command);
				userInput = new UserInput(username, command, message, type);
			}
			return userInput;
		}

		private string composeMessage(string[] strArray)
		{
			var message = "";
			for (int i = 2; i < strArray.Count(); i++)
			{
				message += strArray[i] + " ";
			}
			return message;
		}

		private CommandType composeCommandType(string command)
		{
			CommandType type = CommandType.Post;
			if (command.Equals(FOLLOWS, StringComparison.OrdinalIgnoreCase))
				type = CommandType.Follow;
			if (command.Equals (WALL, StringComparison.OrdinalIgnoreCase))
				type = CommandType.Wall;

			return type;
		}
    }
}
