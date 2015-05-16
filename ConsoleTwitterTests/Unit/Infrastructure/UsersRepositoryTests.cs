using ConsoleTwitter.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using ConsoleTwitter.Domain;

namespace ConsoleTwitterTests.Unit.Infrastructure
{
    [TestFixture]
    public class UsersRepositoryTests
    {
        [Test]
        public void ItShouldGetAUserByUserName()
        {
            var usersList = new List<User>();
            var repository = new UsersRepository();
            var user = repository.GetUser("Ana");

            user.Should().NotBeNull();
        }

        [Test]
        public void ItShouldAddUserToFollowToFollowingList()
        {
            var usersList = new List<User>();
            var repository = new UsersRepository();
            var user = repository.GetUser("Ana");
            var userToFollow = repository.GetUser("Pedro");

            repository.FollowUser(user, userToFollow);

            user.Following.Count().Equals(1);
        }
    }
}
