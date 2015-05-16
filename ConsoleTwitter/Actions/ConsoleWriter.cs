using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Actions
{
    public class ConsoleWriter
    {
        public void WriteWelcomeMessage()
        {
            Console.WriteLine("Welcome to Console Twitter");
            Console.WriteLine("Here some commands you can use:");
            Console.WriteLine("| Command | usage |");
            Console.WriteLine("| Posting | <username> -> <message> |");
            Console.WriteLine("| Reading | <username> |");
            Console.WriteLine("| Following | <user name> follows <another user> |");
            Console.WriteLine("| Wall | <user name> wall |");
        }

        public virtual void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
