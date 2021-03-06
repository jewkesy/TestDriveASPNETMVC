﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ThoughtController : Controller
    {
        //
        // GET: /Thought/

        public ActionResult Index()
        {
            ViewData.Model = Thought.Thoughts;
            return View();
        }

        //
        // GET: /Thought/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Thought/Create

        public ActionResult Create()
        {
            ViewData["Topics"] =
                Topic.Topics.ConvertAll(topic => new SelectListItem {Text = topic.Name, Value = topic.Id.ToString()});
            return View();
        } 

        //
        // POST: /Thought/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Thought/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Thought/Edit/5

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
        // GET: /Thought/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Thought/Delete/5

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

        //
        // GET: /Thought/Process

        public ActionResult Process()
        {
            ViewData.Model = Thought.Thoughts.First();
            return View();
            throw new NotImplementedException();
        }
    }
}
