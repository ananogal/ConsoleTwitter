using ConsoleTwitter.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace ConsoleTwitterTests.Unit.Helpers
{
    [TestFixture]
    public class FormatTimeTests
    {
        [Test]
        public void ItShouldReturnAStringWithOneSecondPassed()
        {
            var dateToFormat = DateTime.Now.AddSeconds(-1);

            var result = FormatTime.Format(dateToFormat);

            result.Should().Be("(1 second ago)");
        }

        [Test]
        public void ItShouldReturnAStringWithTheSecondsPassed()
        {
            var dateToFormat = DateTime.Now.AddSeconds(-5);
            var result = FormatTime.Format(dateToFormat);

            result.Should().Be("(5 seconds ago)");
        }

        [Test]
        public void ItShouldReturnAStringWithOneMinutePassed()
        {
            var dateToFormat = DateTime.Now.AddSeconds(-60);

            var result = FormatTime.Format(dateToFormat);

            result.Should().Be("(1 minute ago)");
        }

        [Test]
        public void ItShouldReturnAStringWithMinutesPassed()
        {
            var dateToFormat = DateTime.Now.AddMinutes(-5);

            var result = FormatTime.Format(dateToFormat);

            result.Should().Be("(5 minutes ago)");
        }

        [Test]
        public void ItShouldReturnAStringWithOneDayPassed()
        {
            var dateToFormat = DateTime.Now.AddDays(-1);

            var result = FormatTime.Format(dateToFormat);

            result.Should().Be("(1 day ago)");
        }

        [Test]
        public void ItShouldReturnAStringWithDaysPassed()
        {
            var dateToFormat = DateTime.Now.AddDays(-5);

            var result = FormatTime.Format(dateToFormat);

            result.Should().Be("(5 days ago)");
        }
    }
}
