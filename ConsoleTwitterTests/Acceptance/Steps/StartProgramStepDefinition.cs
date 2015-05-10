using ConsoleTwitter.Actions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ConsoleTwitterTests.Acceptance.Steps
{
    [Binding]
    public sealed class StartProgramStepDefinition
    {
        WriteToConsole console = Substitute.For<WriteToConsole>();

        [Given(@"I am a user")]
        public void GivenIAmAUser()
        {
        }

        [When(@"I enter the system")]
        public void WhenIEnterTheSystem()
        {
        }

        [Then(@"I see a welcome Message")]
        public void ThenISeeAWelcomeMessage()
        {
            console.Received().WriteWelcomeMessage();
        }

        [Given(@"I enter the system")]
        public void GivenIEnterTheSystem()
        {
        }

        [When(@"I see the welcome message")]
        public void WhenISeeTherWelcomeMessage()
        {
            console.WriteWelcomeMessage();
        }

        [Then(@"the system will wait for a command")]
        public void ThenTheSystemWillWaitForACommand()
        {
            var expectedMessage = "Please enter a command:";

            console.Received().Writeline(expectedMessage);
        }

    }
}
