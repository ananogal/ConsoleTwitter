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
        private List<Post> postsList;

        public PostsRepository(List<Post> postsList)
        {
            this.postsList = postsList;
        }

        public virtual Post Create(User user, string message)
        {
            var post = new Post(user, message);
            postsList.Add(post);
            return post;
        }

        public int Count()
        {
            return postsList.Count();
        }

        public virtual List<Post> GetAllByUser(User user)
        {
            var latest = postsList.Where(p => p.User == user)
                                   .OrderByDescending(p => p.PublishedDate)
                                   .ToList();
            return latest;
        }
    }
}
