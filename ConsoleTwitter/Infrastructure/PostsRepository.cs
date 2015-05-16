using ConsoleTwitter.Domain;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTwitter.Infrastructure
{
	public class PostsRepository
	{
		private List<Post> postsList;

		public PostsRepository()
		{
			this.postsList = new List<Post>();
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
	
		public virtual List<Post> GetAllByUserAndFollowees(User user)
		{
			return postsList.Where(p => p.User == user || user.Following.Any(f => f == p.User))
				.OrderByDescending(p => p.PublishedDate)		
							.ToList();
		}
	}
}
