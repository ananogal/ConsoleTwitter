using ConsoleTwitter.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NSubstitute;
using ConsoleTwitter.Domain;
using System.Threading;

namespace ConsoleTwitterTests.Unit.Infrastructure
{
    [TestFixture]
    public class PostsRepositoryTests
    {
        List<Post> postList;
        PostsRepository repository;
        List<User> usersList;
        User user;

        [SetUp]
        public void BeforeEach()
        {
            postList = new List<Post>();
            repository = new PostsRepository(postList);
            usersList = new List<User>();
            user = new UsersRepository(usersList).GetUser("Ana");
        }

        [Test]
        public void ItShouldCreateANewPost()
        {
            var post = repository.Create(user, "Hello!");

            post.Should().NotBeNull();
        }

        [Test]
        public void ItShouldGetAllPostsForUser()
        {
            repository.Create(user, "Hello!");
            repository.Create(user, "Hello World!");
            var posts = repository.GetAllByUser(user);

            posts.Count().Should().Equals(2);
        }

        [Test]
        public void ItShouldGetAllPostsForUserOrderByPusblishedDateDescending()
        {
            repository.Create(user, "Hello!");
            Thread.Sleep(2);
            repository.Create(user, "Hello World!");
            Thread.Sleep(2);
            repository.Create(user, "The last created!");
            var posts = repository.GetAllByUser(user);

            posts.First().Message.Should().Be("The last created!");
        }
    }
}
