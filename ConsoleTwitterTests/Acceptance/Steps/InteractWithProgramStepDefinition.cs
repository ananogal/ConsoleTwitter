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
using ConsoleTwitter;

namespace ConsoleTwitterTests.Acceptance.Steps
{
    [Binding]
    public sealed class InteractWithProgramStepDefinition
    {
        string userInput = "";
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
            userInput = "Ana -> Hello!";
        }

        [Then(@"I should create a post")]
        public void ThenIShouldCreateAPost()
        {
            var userInputParser = new UserInputParser();
            var posts = new PostsRepository();
            var command = new Program(userInputParser, users, posts,
                                                commandFactory, console);
            command.Execute(userInputParser.Parse(userInput));

            posts.Count().Should().Be(1);
        }

        [When(@"I enter a read command")]
        public void WhenIEnterAReadCommand()
        {
            userInput = "Ana";
        }

        [Then(@"I should see all my posts")]
        public void ThenIShouldSeeAllMyPosts()
        {
            var userInputParser = new UserInputParser();
            var user = users.GetUser(userInput);
            var posts = new PostsRepository();
            posts.Create(user, "Hello!");

            console = Substitute.For<ConsoleWriter>();
            var program = new Program(userInputParser, users, posts,
                                                commandFactory, console);
            program.Execute(userInputParser.Parse(userInput));

            console.Received().WriteMessage(Arg.Any<string>());
        }

        [When(@"I enter a follow command")]
        public void WhenIEnterAFollowCommand()
        {
            userInput = "Ana follows Pedro";
        }

        [Then(@"I should follow the userToFollow")]
        public void ThenIShouldFollowTheUserToFollow()
        {
            var userInputParser = new UserInputParser();
            var posts = new PostsRepository();
            var program = new Program(userInputParser, users, posts,
                                                commandFactory, console);
            program.Execute(userInputParser.Parse(userInput));
            var user = users.GetUser("Ana");
            user.Following.Count().Should().Be(1);

        }

        [When(@"I enter a wall command")]
        public void WhenIEnterAWallCommand()
        {
            userInput = "Ana wall";
        }

        [Then(@"I should see all my posts and the posts from who I follow")]
        public void ThenIShouldSeeAllMyPostsAndThePostsFromWhoIFollow()
        {
            var userInputParser = new UserInputParser();
            var user = users.GetUser("Ana");
            var followingUser = users.GetUser("Pedro");
            users.FollowUser(user, followingUser);
            var posts = new PostsRepository();
            posts.Create(user, "Hello!");
            posts.Create(followingUser, "Hello from Pedro");
            console = Substitute.For<ConsoleWriter>();
            var program = new Program(userInputParser, users, posts,
                                                commandFactory, console);
            program.Execute(userInputParser.Parse(userInput));

            console.Received(2).WriteMessage(Arg.Any<string>());
        }
    }
}
