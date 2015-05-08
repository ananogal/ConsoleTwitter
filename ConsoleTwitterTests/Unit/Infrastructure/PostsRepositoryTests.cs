using ConsoleTwitter.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;

namespace ConsoleTwitterTests.Unit.Infrastructure
{
    [TestFixture]
    public class PostsRepositoryTests
    {
        [Test]
        public void ItShouldCreateANewPost()
        {
            var repository = new PostsRepository();
            var user = new UsersRepository().GetUser("Ana");
            var post = repository.Create(user, "Hello!");

            post.Should().NotBeNull();
        }
    }
}
