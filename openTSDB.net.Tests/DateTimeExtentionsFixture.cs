using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace openTsdbNet.Tests
{
    [TestFixture]
    public class DateTimeExtentionsFixture
    {
        [Test]
        public void ToUnixEpoch_After1970_Utc_DateTime()
        {
            var epoch = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc).ToUnixEpoch();

            Assert.That(epoch, Is.EqualTo(1449878400));
        }

        [Test]
        public void ToUnixEpoch_After1970_Local_DateTime()
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            var dateTime = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc),
                timeZoneInfo);
            var epoch = dateTime.ToUnixEpoch();

            Assert.That(epoch, Is.EqualTo(1449878400));
        }

        [Test]
        public void ToUnixEpoch_Before1970_Utc_DateTime()
        {
            var epoch = new DateTime(1960, 12, 12, 0, 0, 0, DateTimeKind.Utc).ToUnixEpoch();

            Assert.That(epoch, Is.EqualTo(-285724800));
        }

        [Test]
        public void ToUnixEpoch_Before1970_Local_DateTime()
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            var dateTime = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1960, 12, 12, 0, 0, 0, DateTimeKind.Utc),
                timeZoneInfo);
            var epoch = dateTime.ToUnixEpoch();

            Assert.That(epoch, Is.EqualTo(-285724800));
        }
    }
}