using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class TopicController : Controller
    {
        //
        // GET: /Topic/

        public ActionResult Index()
        {
            ViewData.Model = Topic.Topics;
            return View();
        }

        //
        // GET: /Topic/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Topic/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Topic/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var newTopic = new Topic
                                   {
                                       Id = Convert.ToInt32(collection["Id"]),
                                       Name = collection["Name"],
                                       Colour = ColorTranslator.FromHtml("#" + collection["Colour"])
                                   };


                Topic.Topics.Add(newTopic);
                TempData["Message"] = "Your topic has been added successfully.";

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Topic/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Topic/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Topic/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Topic/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
