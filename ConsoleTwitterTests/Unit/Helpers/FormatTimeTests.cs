using ConsoleTwitter.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ConsoleTwitter.Infrastructure;
using NodaTime.Testing;
using NodaTime;

namespace ConsoleTwitterTests.Unit.Helpers
{
    [TestFixture]
    public class FormatTimeTests
    {
        private Instant now = Instant.FromUtc(2015, 1, 1, 12, 0, 0);

        [SetUp]
        public void BeforeEach()
        {
            Clock.ClockExpression = () => new FakeClock(now).Now.ToDateTimeUtc();
        }

        [Test]
        public void ItShouldReturnAStringWithOneSecondPassed()
        {
            var dateToFormat = Clock.Now;
            AdjustClockForElapsedTime(Duration.FromSeconds(1));
            
            var result = FormatTime.Format(dateToFormat);

            result.Should().Be("(1 second ago)");
        }

        [Test]
        public void ItShouldReturnAStringWithTheSecondsPassed()
        {
            var dateToFormat = Clock.Now;
            AdjustClockForElapsedTime(Duration.FromSeconds(5));

            var result = FormatTime.Format(dateToFormat);

            result.Should().Be("(5 seconds ago)");
        }

        [Test]
        public void ItShouldReturnAStringWithOneMinutePassed()
        {
            var dateToFormat = Clock.Now;
            AdjustClockForElapsedTime(Duration.FromMinutes(1));

            var result = FormatTime.Format(dateToFormat);

            result.Should().Be("(1 minute ago)");
        }

        [Test]
        public void ItShouldReturnAStringWithMinutesPassed()
        {
            var dateToFormat = Clock.Now;
            AdjustClockForElapsedTime(Duration.FromMinutes(5));

            var result = FormatTime.Format(dateToFormat);

            result.Should().Be("(5 minutes ago)");
        }

        [Test]
        public void ItShouldReturnAStringWithOneDayPassed()
        {
            var dateToFormat = Clock.Now;
            AdjustClockForElapsedTime(Duration.FromStandardDays(1));

            var result = FormatTime.Format(dateToFormat);

            result.Should().Be("(1 day ago)");
        }

        [Test]
        public void ItShouldReturnAStringWithDaysPassed()
        {
            var dateToFormat = Clock.Now;
            AdjustClockForElapsedTime(Duration.FromStandardDays(5));

            var result = FormatTime.Format(dateToFormat);

            result.Should().Be("(5 days ago)");
        }

        private void AdjustClockForElapsedTime(Duration elapsed)
        {
            Clock.ClockExpression = () => new FakeClock(now + elapsed).Now.ToDateTimeUtc();
        }
    }
}
