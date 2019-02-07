using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTsdbNet;
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
                OpenTsdbFactory.Instance(TsdbOptions.New("http://localhost"), nameInput);
            });
        }

        [TestMethod]
        public void CreateNamedInstance_InvalidOptions_ArgumentException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                OpenTsdbFactory.Instance( null, "test");
            });
        }

        [TestMethod]
        public void CreateNamedInstance_DuplicateName_SameInstanceReturned()
        {
            var originalInstance = OpenTsdbFactory.Instance(TsdbOptions.New("http://localhost"), "test");
            
            var secondInstance = OpenTsdbFactory.Instance(TsdbOptions.New("http://localhost"), "test");
            
            Assert.AreSame(originalInstance, secondInstance);
        }
        
        [TestMethod]
        public void CreateNamedInstance_ValidOptions_InstanceCreated()
        {
            var manager = OpenTsdbFactory.Instance(TsdbOptions.New("http://localhost"), "test");
            
            Assert.IsNotNull(manager);
        }
   
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow(" ")]
        public void IsNamedDefined_InvalidName_False(string nameInput)
        {
            Assert.IsFalse(OpenTsdbFactory.IsInstanceDefined(nameInput));
        }

        [TestMethod]
        public void IsNamedDefined_ExistingName_True()
        {
            OpenTsdbFactory.Instance(TsdbOptions.New("http://localhost"), "test");

            Assert.IsTrue(OpenTsdbFactory.IsInstanceDefined("test"));
        }

        [TestMethod]
        public void IsNamedDefined_NonExistingName_False()
        {
            
            Assert.IsFalse(OpenTsdbFactory.IsInstanceDefined("test"));
        }
    }
}