using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTwitter
{
    public struct UserInput
    {
        string username, command, action;

        public string Action
        {
            get { return action; }
        }

        public string Command
        {
            get { return command; }
        }

        public string Username
        {
            get { return username; }
        }

        public UserInput(string username, string command, string action)
        {
            this.username = username;
            this.command = command;
            this.action = action;
        }
    }
}
