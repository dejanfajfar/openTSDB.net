using System;
using NUnit.Framework;

namespace openTsdbNet.Tests
{
    [TestFixture]
    public class DateTimeExtentionsFixture
    {
        [Test]
        public void GetUnixEpochFromValidDateTime()
        {
            var epoch = new DateTime(2015, 12, 12).ToUnixEpoch();

            Assert.That(epoch, Is.EqualTo(1449874800));
        }

        [Test]
        public void GetUnixEpochFromDateBefore1970()
        {
            var epoch = new DateTime(1960, 12, 12).ToUnixEpoch();

            Assert.That(epoch, Is.EqualTo(-285728400));
        }


    }
}