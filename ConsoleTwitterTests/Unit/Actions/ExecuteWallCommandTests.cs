﻿using System;
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
		WallCommand command;

		[SetUp]
		public void BeforeEach()
		{
			input = "Ana wall";
			var createUserInput = new UserInputParser(input);
			userInput = createUserInput.Parse();
			users = Substitute.For<UsersRepository>(new List<User>());
			posts = Substitute.For<PostsRepository>(new List<Post>());
			command = new WallCommand(userInput, users, posts);
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