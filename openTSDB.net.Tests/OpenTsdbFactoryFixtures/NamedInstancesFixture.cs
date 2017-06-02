using System;
using System.Collections.Generic;
using NUnit.Framework;
using openTSDB.net.Models;

namespace openTSDB.net.Tests.OpenTsdbFactoryFixtures
{
    [TestFixture]
    public class NamedInstancesFixture
    {
        [SetUp]
        public void Setup()
        {
            OpenTsdbFactory.ClearNamed();
        }
        
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void CreateNamedInstance_InvalidName_ArgumentException(string nameInput)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                OpenTsdbFactory.CreateNamed(nameInput, new TsdbOptions(new Uri("http://localhost"), "Test"));
            });
        }

        [Test]
        public void CreateNamedInstance_InvalidOptions_ArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                OpenTsdbFactory.CreateNamed("test", null);
            });
        }

        [Test]
        public void CreateNamedInstance_DuplicateName_ArgumentException()
        {
            OpenTsdbFactory.CreateNamed("test", new TsdbOptions(new Uri("http://localhost"), "Test"));
            
            Assert.Throws<ArgumentException>(() =>
            {
                OpenTsdbFactory.CreateNamed("test", new TsdbOptions(new Uri("http://localhost"), "Test"));
            });
        }
        
        [Test]
        public void CreateNamedInstance_ValidOptions_InstanceCreated()
        {
            OpenTsdbFactory.CreateNamed("test", new TsdbOptions(new Uri("http://localhost"), "Test"));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void GetNamed_InvalidName_ArgumentExceptionThrown(string nameInput)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                OpenTsdbFactory.GetNamed(nameInput);
            });
        }

        [Test]
        public void GetNamed_NonExistingKey_KeyNotFoundException()
        {
            Assert.Throws<KeyNotFoundException>(() =>
            {
                OpenTsdbFactory.GetNamed("I am not there");
            });
        }

        [Test]
        public void GetNamed_ValidName_InstanceReturned()
        {
            var testIntance = OpenTsdbFactory.CreateNamed("test", new TsdbOptions(new Uri("http://localhost"), "Test"));

            var compareInstance = OpenTsdbFactory.GetNamed("test");
            
            Assert.That(testIntance, Is.EqualTo(compareInstance));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void IsNamedDefined_InvalidName_False(string nameInput)
        {
            Assert.That(OpenTsdbFactory.IsNamedDefined(nameInput), Is.False);
        }

        [Test]
        public void IsNamedDefined_ExistingName_True()
        {
            OpenTsdbFactory.CreateNamed("test", new TsdbOptions(new Uri("http://localhost"), "Test"));
            
            Assert.That(OpenTsdbFactory.IsNamedDefined("test"), Is.True);
        }

        [Test]
        public void IsNamedDefined_NonExistingName_False()
        {
            
            Assert.That(OpenTsdbFactory.IsNamedDefined("test"), Is.False);
        }
    }
}