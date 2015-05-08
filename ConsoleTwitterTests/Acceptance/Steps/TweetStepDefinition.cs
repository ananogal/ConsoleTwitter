﻿using ConsoleTwitter.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using FluentAssertions;
using NSubstitute;
using ConsoleTwitter;
using ConsoleTwitter.Infrastructure;
using ConsoleTwitter.Domain;

namespace ConsoleTwitterTests.Acceptance.Steps
{
    [Binding]
    public sealed class TweetStepDefinition
    {
        [Given(@"the system is waiting for a command")]
        public void GivenTheSystemIsWaitingForACommand()
        {
        }

        [When(@"I enter a post command")]
        public void WhenIEnterAPostCommand()
        {
        }

        [Then(@"I should create a post command")]
        public void ThenIShouldCreateAPostCommand()
        {
            var stringCommand = "Ana -> Hello!";
            var factory = new CreateUserInputFromPostCommand(stringCommand);
            var users = new UsersRepository();
            var posts = new PostsRepository();
            var command = new ExecutePostCommand(factory, users, posts);

            command.Execute();

            posts.Count().Should().Equals(1);
        }


    }
}
