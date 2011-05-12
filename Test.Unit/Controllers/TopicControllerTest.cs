using System;
using System.Drawing;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NUnit.Framework;
using Web.Controllers;
using Web.Models;

namespace Test.Unit.Controllers
{
    [TestFixture]
    public class TopicControllerTest
    {
        [Test]
        public void ShouldHaveListOfTopicsWithNameAndColour()
        {
            var topic = new Topic {Id = 1, Colour = Color.Red, Name = "Work"};

            var model = ((ViewResult) new TopicController().Index()).ViewData.Model;

            Assert.AreEqual(topic, ((List<Topic>) model)[0]);
        }
    }
}
