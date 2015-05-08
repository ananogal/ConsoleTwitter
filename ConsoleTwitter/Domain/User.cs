using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Domain
{
    public class User
    {
        private string username;

        public string Username
        {
            get { return username; }
        }

        public User(string username)
        {
            this.username = username;
        }
    }
}
