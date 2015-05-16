using ConsoleTwitter.Actions;
using ConsoleTwitter.Domain;
using ConsoleTwitter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using FluentAssertions;
using NSubstitute;

namespace ConsoleTwitterTests.Acceptance.Steps
{
    [Binding]
    public sealed class InteractWithProgramStepDefinition
    {
        string stringCommand = "";
        UsersRepository users = new UsersRepository();
        CommandFactory commandFactory = new CommandFactory();
        ConsoleWriter console = new ConsoleWriter();

        [Given(@"the system is waiting for a command")]
        public void GivenTheSystemIsWaitingForACommand()
        {
        }

        [When(@"I enter a post command")]
        public void WhenIEnterAPostCommand()
        {
            stringCommand = "Ana -> Hello!";
        }

        [Then(@"I should create a post")]
        public void ThenIShouldCreateAPost()
        {
            var userInputFactory = new UserInputParser(stringCommand);
            var posts = new PostsRepository();
            var command = new Command(userInputFactory, users, posts,
                                                commandFactory, console);
            command.Execute();

            posts.Count().Should().Be(1);
        }

        [When(@"I enter a read command")]
        public void WhenIEnterAReadCommand()
        {
            stringCommand = "Ana";
        }

        [Then(@"I should see all my posts")]
        public void ThenIShouldSeeAllMyPosts()
        {
            var userInputFactory = new UserInputParser(stringCommand);
            var user = users.GetUser(stringCommand);
            var posts = new PostsRepository();
            posts.Create(user, "Hello!");

            console = Substitute.For<ConsoleWriter>();
            var command = new Command(userInputFactory, users, posts,
                                                commandFactory, console);
            command.Execute();

            console.Received().WriteMessage(Arg.Any<string>());
        }

        [When(@"I enter a follow command")]
        public void WhenIEnterAFollowCommand()
        {
            stringCommand = "Ana follows Pedro";
        }

        [Then(@"I should follow the userToFollow")]
        public void ThenIShouldFollowTheUserToFollow()
        {
            var userInputFactory = new UserInputParser(stringCommand);
            var posts = new PostsRepository();
            var command = new Command(userInputFactory, users, posts,
                                                commandFactory, console);
            command.Execute();
            var user = users.GetUser("Ana");
            user.Following.Count().Should().Be(1);

        }

        [When(@"I enter a wall command")]
        public void WhenIEnterAWallCommand()
        {
            stringCommand = "Ana wall";
        }

        [Then(@"I should see all my posts and the posts from who I follow")]
        public void ThenIShouldSeeAllMyPostsAndThePostsFromWhoIFollow()
        {
            var userInputFactory = new UserInputParser(stringCommand);
            var user = users.GetUser("Ana");
            var followingUser = users.GetUser("Pedro");
            users.FollowUser(user, followingUser);
            var posts = new PostsRepository();
            posts.Create(user, "Hello!");
            posts.Create(followingUser, "Hello from Pedro");
            console = Substitute.For<ConsoleWriter>();
            var command = new Command(userInputFactory, users, posts,
                                                commandFactory, console);
            command.Execute();

            console.Received(2).WriteMessage(Arg.Any<string>());
        }
    }
}
