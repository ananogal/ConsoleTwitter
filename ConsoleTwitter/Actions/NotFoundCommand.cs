using ConsoleTwitter.Domain;
using System.Collections.Generic;

namespace ConsoleTwitter.Actions
{
    public class NotFoundCommand : ICommand
    {
        public List<Post> Execute()
        {
            return new List<Post>();
        }
    }
}
