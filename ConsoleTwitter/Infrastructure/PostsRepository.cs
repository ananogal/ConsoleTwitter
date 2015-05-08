using ConsoleTwitter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Infrastructure
{
   // private List<Post> posts;

    public class PostsRepository
    {
        List<Post> posts;

        public PostsRepository()
        {
            posts = new List<Post>();
        }

        public Post Create(User user, string message)
        {
            var post = new Post(user, message);
            posts.Add(post);
            return post;
        }

        public int Count()
        {
            return posts.Count();
        }
    }
}
