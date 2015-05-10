using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Domain
{
    public class User
    {
        private string username;
        private List<User> following;

        public List<User> Following
        {
            get { return following; }
        }

        public string Username
        {
            get { return username; }
        }

        public User(string username)
        {
            this.username = username;
            this.following = new List<User>();
        }
    }
}
