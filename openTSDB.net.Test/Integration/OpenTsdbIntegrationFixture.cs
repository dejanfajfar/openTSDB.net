using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using openTSDB.net;
using openTSDB.net.Models;

namespace OpenTsdb.Net.Test.Integration
{
    [TestClass]
    public class OpenTsdbIntegrationFixture
    {
        private const string _openTsdbUrl = "http://11.0.0.101:4242";

        [TestMethod]
        [Ignore("Only for integration purposes. !! Must refactor !!")]
        public void SubmitSinglePointData()
        {
            var pushResult = OpenTsdbFactory
                .CreateNew(new TsdbOptions(new Uri(_openTsdbUrl), "DFMac01"))
                .PushAsync("ping", new Random().Next());

            Assert.AreEqual(pushResult.Result.ResponseHttpStatusCode, 204);
        }
    }
}