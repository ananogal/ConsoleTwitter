using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTwitter.Domain
{
    public enum CommandType
    { 
        Post = 1,
        Read,
        Follow,
        Wall
    }

    public struct UserInput
    {
        string username, command, action;
        CommandType commandType;

        public CommandType CommandType
        {
            get { return commandType; }
        }

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

        public UserInput(string username, string command, string action, CommandType type)
        {
            this.username = username;
            this.command = command;
            this.action = action;
            this.commandType = type;
        }
    }
}
