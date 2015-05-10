using ConsoleTwitter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Actions
{
    public class CreateUserInput
    {
        private string stringCommand;

        public CreateUserInput(string stringCommand)
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
                userInput = new UserInput(userInputArray[0].Trim(), userInputArray[1].Trim(), message, CommandType.Post);
            }
            return userInput; 
        }
    }
}
