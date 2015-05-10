using System;
using NUnit.Framework;
using ConsoleTwitter.Domain;
using ConsoleTwitter.Infrastructure;
using ConsoleTwitter.Actions;
using NSubstitute;
using System.Collections.Generic;

namespace ConsoleTwitterTests.Unit.Actions
{
	[TestFixture]
	public class ExecuteWallCommandTests
	{
		string input;
		UserInput userInput;
		UsersRepository users;
		PostsRepository posts;
		ExecuteWallCommand command;

		[SetUp]
		public void BeforeEach()
		{
			input = "Ana wall";
			var createUserInput = new UserInputFactory(input);
			userInput = createUserInput.Create();
			users = Substitute.For<UsersRepository>(new List<User>());
			posts = Substitute.For<PostsRepository>(new List<Post>());
			command = new ExecuteWallCommand(userInput, users, posts);
		}

		[Test]
		public void ColaboratesWithUsersRepositoryToGetAUser()
		{
			command.Execute();
			users.Received().GetUser(Arg.Any<string>());
		}

		[Test]
		public void ColaboratesWithPostsRepositoryToGetPosts()
		{
			command.Execute ();
			posts.Received().GetAllByUserAndFollowees(Arg.Any<User>());
		}
	}
}