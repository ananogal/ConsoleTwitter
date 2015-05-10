using ConsoleTwitter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTwitter.Actions
{
    public interface IExecuteCommand
    {
        List<Post> Execute();
    }
}
