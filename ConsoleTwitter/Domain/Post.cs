using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Domain
{
    public class Post
    {
        private User user;
        private string message;

        public Post(User user, string message)
        {
            this.user = user;
            this.message = message;
        }

    }
}
