using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class TodoController : Controller
    {
        //
        // GET: /Todo/

        public ActionResult Index()
        {
            ViewData.Model = Todo.ThingsToBeDone;
            return View();
        }

        //
        // GET: /Todo/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Todo/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Todo/Create

        [HttpPost]
        public ActionResult Create(Todo todo)
        {
            try
            {
                // TODO: Add insert logic here
                Todo.ThingsToBeDone.Add(todo);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                //throw e; //needs to be handled properly
                return View();
            }
        }
        
        //
        // GET: /Todo/Edit/5
 
        public ActionResult Edit(string title)
        {
            ViewData.Model = Todo.ThingsToBeDone.Find(todo => todo.Title == title);
            return View();
        }

        //
        // POST: /Todo/Edit/5

        [HttpPost]
        public ActionResult Edit(string oldTitle, Todo editedTodo)
        {
            try
            {
                // TODO: Add update logic here
                Todo.ThingsToBeDone.RemoveAll(aTodo => aTodo.Title == oldTitle);
                Todo.ThingsToBeDone.Add(editedTodo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Todo/Delete/5
 
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Todo/Delete/5

        //[HttpPost] removed for now
        public ActionResult Delete(string title)
        {
            try
            {
                // TODO: Add delete logic here
                Todo.ThingsToBeDone.RemoveAll(todo => todo.Title == title);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Convert(Thought thought, string outcome)
        {
            var newTodo = new Todo
                              {
                                  Title = thought.Name,
                                  Outcome = outcome,
                                  Topic = Topic.Topics.Find(topic => topic.Id == thought.Topic.Id)
                              };

            CreateTodo(newTodo);

            Thought.Thoughts.RemoveAll(thoughtToRemove => thoughtToRemove.Name == thought.Name);

            return RedirectToAction("Process", "Thought");
        }

        private static void CreateTodo(Todo todo)
        {
            Todo.ThingsToBeDone.Add(todo);
        }
    }
}
