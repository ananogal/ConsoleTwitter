using ConsoleTwitter.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NSubstitute;
using ConsoleTwitter.Domain;

namespace ConsoleTwitterTests.Unit.Infrastructure
{
    [TestFixture]
    public class PostsRepositoryTests
    {
        [Test]
        public void ItShouldCreateANewPost()
        {
            var postList = new List<Post>();
            var repository = new PostsRepository(postList);
            var usersList = new List<User>();
            var user = new UsersRepository(usersList).GetUser("Ana");
            var post = repository.Create(user, "Hello!");

            post.Should().NotBeNull();
        }

        [Test]
        public void ItShouldGetAllPostsForUser()
        {
            var postList = new List<Post>();
            var repository = new PostsRepository(postList);
            var usersList = new List<User>();
            var user = new UsersRepository(usersList).GetUser("Ana");
            repository.Create(user, "Hello!");
            var posts = repository.GetAllByUser(user);

            posts.Count().Should().BeGreaterOrEqualTo(1);
        }
    }
}
