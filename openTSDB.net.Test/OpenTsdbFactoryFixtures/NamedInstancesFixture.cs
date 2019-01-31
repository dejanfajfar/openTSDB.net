using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using openTSDB.net;
using OpenTsdbNet.models;

namespace OpenTsdb.Net.Test.OpenTsdbFactoryFixtures
{
    [TestClass]
    public class NamedInstancesFixture
    {
        [TestInitialize]
        public void Setup()
        {
            OpenTsdbFactory.ClearNamed();
        }
        
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow(" ")]
        public void CreateNamedInstance_InvalidName_ArgumentException(string nameInput)
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                OpenTsdbFactory.CreateNamed(nameInput, new TsdbOptions(new Uri("http://localhost"), "Test"));
            });
        }

        [TestMethod]
        public void CreateNamedInstance_InvalidOptions_ArgumentException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                OpenTsdbFactory.CreateNamed("test", null);
            });
        }

        [TestMethod]
        public void CreateNamedInstance_DuplicateName_ArgumentException()
        {
            OpenTsdbFactory.CreateNamed("test", new TsdbOptions(new Uri("http://localhost"), "Test"));
            
            Assert.ThrowsException<ArgumentException>(() =>
            {
                OpenTsdbFactory.CreateNamed("test", new TsdbOptions(new Uri("http://localhost"), "Test"));
            });
        }
        
        [TestMethod]
        public void CreateNamedInstance_ValidOptions_InstanceCreated()
        {
            var manager = OpenTsdbFactory.CreateNamed("test", new TsdbOptions(new Uri("http://localhost"), "Test"));
            
            Assert.IsNotNull(manager);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow(" ")]
        public void GetNamed_InvalidName_ArgumentExceptionThrown(string nameInput)
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                OpenTsdbFactory.GetNamed(nameInput);
            });
        }

        [TestMethod]
        public void GetNamed_NonExistingKey_KeyNotFoundException()
        {
            Assert.ThrowsException<KeyNotFoundException>(() =>
            {
                OpenTsdbFactory.GetNamed("I am not there");
            });
        }

        [TestMethod]
        public void GetNamed_ValidName_InstanceReturned()
        {
            var testIntance = OpenTsdbFactory.CreateNamed("test", new TsdbOptions(new Uri("http://localhost"), "Test"));

            var compareInstance = OpenTsdbFactory.GetNamed("test");
            
            Assert.AreEqual(testIntance, compareInstance);
        }
        
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow(" ")]
        public void IsNamedDefined_InvalidName_False(string nameInput)
        {
            Assert.IsFalse(OpenTsdbFactory.IsNamedDefined(nameInput));
        }

        [TestMethod]
        public void IsNamedDefined_ExistingName_True()
        {
            OpenTsdbFactory.CreateNamed("test", new TsdbOptions(new Uri("http://localhost"), "Test"));

            Assert.IsTrue(OpenTsdbFactory.IsNamedDefined("test"));
        }

        [TestMethod]
        public void IsNamedDefined_NonExistingName_False()
        {
            
            Assert.IsFalse(OpenTsdbFactory.IsNamedDefined("test"));
        }
    }
}