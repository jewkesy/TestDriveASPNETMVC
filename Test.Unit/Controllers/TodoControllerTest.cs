using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Web.Models;
using Web.Controllers;
using NUnit.Framework;

namespace Test.Unit.Controllers
{
    [TestFixture]
    public class TodoControllerTest
    {
        [Test]
        public void ShouldDisplayAListOfTodoItems()
        {
            var viewResult = (ViewResult) new TodoController().Index();
            Assert.AreEqual(Todo.ThingsToBeDone, viewResult.ViewData.Model);   
        }

        [Test]
        public void ShouldLoadCreateView()
        {
            var viewResult = (ViewResult) new TodoController().Create();
            Assert.AreEqual(string.Empty, viewResult.ViewName); //empty if normal mvc convention
        }

        [Test]
        public void ShouldAddTodoItem()
        {
            var todo = new Todo {Title = "Learn more about ASP.NET MVC Controllers"};
            var redirectToRouteresult = (RedirectToRouteResult) new TodoController().Create(todo);
            Assert.Contains(todo, Todo.ThingsToBeDone);
            Assert.AreEqual("Index", redirectToRouteresult.RouteValues["action"]);
        }

        [Test]
        public void ShouldDeleteTodoItem()
        {
            var mistakeTodo = Todo.ThingsToBeDone[0];
            var redirectToResultRoute = (RedirectToRouteResult) new TodoController().Delete(mistakeTodo.Title);

            Assert.IsFalse(Todo.ThingsToBeDone.Contains(mistakeTodo));
            Assert.AreEqual("Index", redirectToResultRoute.RouteValues["action"]);
        }

        [Test]
        public void ShouldLoadATodoItemForEditing()
        {
            var editTodo = Todo.ThingsToBeDone[0];

            var viewResult = (ViewResult) new TodoController().Edit(editTodo.Title);

            Assert.AreEqual(editTodo, viewResult.ViewData.Model);
        }

        [Test]
        public void ShouldEditTodoItem()
        {
            var editedTodo = new Todo {Title = "Get a LOT more milk"};

            var redirectToRouteResult = (RedirectToRouteResult) new TodoController().Edit("Get Milk", editedTodo);

            Assert.Contains(editedTodo, Todo.ThingsToBeDone);
            Assert.AreEqual("Index", redirectToRouteResult.RouteValues["action"]);
        }

        [SetUp]
        public void setup()
        {
            Todo.ThingsToBeDone = new List<Todo>
                                      {
                                          new Todo {Title = "Get Milk"},

                                          new Todo {Title = "Bring Home Bacon"}
                                      };
        }
    }
}
