using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Web.Mvc;
using NUnit.Framework;
using Web.Controllers;
using Web.Models;

namespace Test.Unit.Controllers
{
    [TestFixture]
    public class ThoughtControllerTest
    {
        [Test]
        public void ShouldDisplayFirstThoughtWhenProcessingThoughts()
        {
            var expectedThought = Thought.Thoughts.First();
            var result = (ViewResult) new ThoughtController().Process();
            Assert.AreEqual(expectedThought, result.ViewData.Model);
        }

        [Test]
        public void ShouldListThoughtsWhenIndexIsCalled()
        {
            var result = (ViewResult) new ThoughtController().Index();
            Assert.AreEqual(Thought.Thoughts, result.ViewData.Model);
        }

        [Test]
        public void ShouldProvideAListOfTopicsForCreatingNewthoughts()
        {
            var expectedListItems =
                Topic.Topics.ConvertAll(topic => new SelectListItem {Text = topic.Name, Value = topic.Id.ToString()});

            var result = (ViewResult) new ThoughtController().Create();

            var firstTopic = ((List<SelectListItem>) result.ViewData["Topics"])[0];

            Assert.AreEqual(expectedListItems[0].Value, firstTopic.Value);
            Assert.AreEqual(expectedListItems[0].Text, firstTopic.Text);
        }

        [Test]
        [Ignore("Bottom of page 74 - haven't worked it out yet")]
        public void ShouldAddTodoItem()
        {
            //var thought = new Thought { Name = "Learn more about ASP.NET MVC Controllers", Topic = new Topic{ Name = "TestCreate", Colour = Color.Red, Id = 1} };
            //var redirectToRouteresult = (RedirectToRouteResult)new ThoughtController().Create(thought);
            //Assert.Contains(todo, Todo.ThingsToBeDone);
            //Assert.AreEqual("Index", redirectToRouteresult.RouteValues["action"]);
        }
    }
}
