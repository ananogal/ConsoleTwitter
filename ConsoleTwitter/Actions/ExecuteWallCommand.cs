using ConsoleTwitter.Actions;
using ConsoleTwitter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTwitter.Infrastructure;

namespace ConsoleTwitter.Actions
{
	public class ExecuteWallCommand: IExecuteCommand
	{
		private UserInput userInput;
		private UsersRepository usersRepository;
		private PostsRepository postsRepository;

		public ExecuteWallCommand (UserInput userInput, UsersRepository users, PostsRepository posts)
		{
			this.userInput = userInput;
			this.postsRepository = posts;
			this.usersRepository = users;
		}

		public List<Post> Execute ()
		{
			var user = usersRepository.GetUser (userInput.Username);
			return postsRepository.GetAllByUserAndFollowees(user);
		}
	}


}
