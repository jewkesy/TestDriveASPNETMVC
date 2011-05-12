using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Web.Models;

namespace Test.Unit.Models
{
    [TestFixture]
    public class TopicTest
    {
        private Topic _workTopic;

        [SetUp]
        public void Setup()
        {
            _workTopic = new Topic{Id = 1, Colour = Color.White, Name = "Work"};
        }

        [Test]
        public void ShouldBeEqualByValue()
        {
            var anotherWorktopic = new Topic {Id = 1, Colour = Color.White, Name = "Work"};
            Assert.AreEqual(_workTopic, anotherWorktopic);
        }

        [Test]
        public void ShouldNotBeEqualByValue()
        {
            var personalTopic = new Topic {Id = 2, Colour = Color.Red, Name = "Personal"};
            Assert.AreNotEqual(_workTopic, personalTopic);
        }

        [Test]
        public void ShouldConverrtColourToHexValue()
        {
            var aShadeOfRedTopic = new Topic {Colour = Color.FromArgb(0, 208, 0, 0)};
            Assert.AreEqual("#D00000", aShadeOfRedTopic.ColourInWebHex());
        }
    }
}
