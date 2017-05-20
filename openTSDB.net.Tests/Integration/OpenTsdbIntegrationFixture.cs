using System;
using NUnit.Framework;
using openTSDB.net.Models;

namespace openTSDB.net.Tests.Integration
{
    [TestFixture]
    public class OpenTsdbIntegrationFixture
    {
        private const string _openTsdbUrl = "http://11.0.0.101:4242";

        [Test]
        [Ignore("Only for integration purposes. !! Must refactor !!")]
        public void SubmitSinglePointData()
        {
            var pushResult = OpenTsdbFactory.TsdbManager(new TsdbOptions
            {
                OpenTsdbServerUri = new Uri(_openTsdbUrl),
                DefaultTags = new TagsCollection("DFMac01")
            }).Push("ping", new Random().Next());

            Assert.That(pushResult.Result.ResponseHttpStatusCode, Is.EqualTo(204));
        }
    }
}