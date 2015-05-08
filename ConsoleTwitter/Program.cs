using ConsoleTwitter.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTwitter
{
    class Program
    {
        
        static void Main(string[] args)
        {
            WriteInstructions();

            Console.ReadLine();
        }

        public static void WriteInstructions()
        {
            var console = new WriteToConsole();
            console.WriteWelcomeMessage();
            console.Writeline("Please enter a command:");
        }

        private static void WaitForCommand()
        {
            var console = new WriteToConsole();
            
            do
            {
                console.Writeline("Please enter a command:");
                //IUserInputFactory readCommand;

                //if (command.Contains("->"))
                //{
                //    readCommand = new CreateUserInputFromPostCommand(command);
                //    var userInput = readCommand.Create();
                //}

            } while (true);
        }
    }
}
