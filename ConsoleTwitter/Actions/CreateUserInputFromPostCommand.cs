using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Actions
{
    public class CreateUserInputFromPostCommand
    {
        private string userInput;

        public CreateUserInputFromPostCommand(string userInput)
        {
            this.userInput = userInput;
        }

        public UserInput Create()
        {
            var separator = new char[] { ' ' };
            var userInputArray = userInput.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return new UserInput(userInputArray[0].Trim(), userInputArray[1].Trim(), userInputArray[2].Trim());
        }
    }
}
