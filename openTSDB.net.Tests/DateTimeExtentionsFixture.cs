﻿using System;
using NUnit.Framework;

namespace openTSDB.net.Tests
{
    [TestFixture]
    public class DateTimeExtentionsFixture
    {
        [Test]
        public void GetUnixEpochFromValidDateTime()
        {
            var epoch = new DateTime(2015, 12, 12, 0, 0, 0, DateTimeKind.Utc).ToUnixEpoch();

            Assert.That(epoch, Is.EqualTo(1449878400));
        }

        [Test]
        public void GetUnixEpochFromDateBefore1970()
        {
            var epoch = new DateTime(1960, 12, 12, 0, 0, 0, DateTimeKind.Utc).ToUnixEpoch();

            Assert.That(epoch, Is.EqualTo(-285724800));
        }


    }
}