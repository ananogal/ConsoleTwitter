using ConsoleTwitter.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using FluentAssertions;
using ConsoleTwitter.Infrastructure;
using ConsoleTwitter.Domain;

namespace ConsoleTwitterTests.Acceptance.Steps
{
    [Binding]
    public sealed class ReadPostsStepDefinition
    {
        [Given(@"I have entered my username")]
        public void GivenIHaveEnteredMyUsername()
        {
        }

        [When(@"I press enter")]
        public void WhenIPressEnter()
        {
        }

        [Then(@"I sould see all my posts")]
        public void ThenISouldSeeAllMyPosts()
        {
            //var stringCommand = "Ana";
            //var userInput = new CreateUserInputFromReadCommand(stringCommand);
            //var users = new UsersRepository();
            //var user = users.GetUser(stringCommand);
            //var postsList = new List<Post>{new Post(user, "Hello!")};
            //var posts = new PostsRepository(postsList);
            //var command = new ExecuteReadCommand(userInput, posts, users);
            //var myPosts = command.Execute();

            //myPosts.Count().Should().BeGreaterOrEqualTo(1);
        }
    }
}
