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

        [Test]
        public void ShouldCreateTopicAndNotifyTheUser()
        {
            var professionalDevelopment = new Topic{Id = 3, Colour = ColorTranslator.FromHtml("#000000"), Name = "Professional Development"};
            var formValues = new FormCollection
                                 {
                                     {"Id", professionalDevelopment.Id.ToString()},
                                     {"Name", professionalDevelopment.Name},
                                     {"Colour", professionalDevelopment.ColourInWebHex().Trim('#')}
                                 };

            var controller = new TopicController();

            var result = (RedirectToRouteResult) controller.Create(formValues);
            Assert.Contains(professionalDevelopment, Topic.Topics);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Your topic has been added successfully.", controller.TempData["message"]);

        }
    }
}
