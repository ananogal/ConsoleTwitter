using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Domain
{
    public class Post
    {
        private User user;

        public User User
        {
            get { return user; }
        }

        private string message;
        public string Message
        {
            get { return message; }
        }

        private DateTime publishedDate;
        public DateTime PublishedDate
        {
            get { return publishedDate; }
        }

        public Post(User user, string message)
        {
            this.user = user;
            this.message = message;
            this.publishedDate = DateTime.Now;
        }

    }
}
