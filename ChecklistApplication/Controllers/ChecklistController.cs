﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChecklistApplication.Models;
using WebMatrix.WebData;

namespace ChecklistApplication.Controllers
{
    public class ChecklistController : Controller
    {
        private ChecklistDb db = new ChecklistDb();

        //
        // GET: /Checklist/

        public ActionResult Index()
        {
            return View(db.Checklists.ToList());
        }

        //
        // GET: /Checklist/Details/5

        public ActionResult Details(int id = 0)
        {
            Checklist checklist = db.Checklists.Find(id);
            if (checklist == null)
            {
                return HttpNotFound();
            }
            return View(checklist);
        }

        //
        // GET: /Checklist/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Checklist/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Checklist checklist)
        {
            if (ModelState.IsValid)
            {
                db.Checklists.Add(checklist);
                db.SaveChanges();
                Workflow workflow = new Workflow();
                workflow.ChecklistID = checklist.ChecklistID;
                workflow.StepID = 2;
                workflow.UserProfileID = WebSecurity.GetUserId(User.Identity.Name);
                workflow.WorkFlowStatusId = 1;

                db.Workflows.Add(workflow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            
            return View(checklist);
        }

        //
        // GET: /Checklist/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Checklist checklist = db.Checklists.Find(id);
            if (checklist == null)
            {
                return HttpNotFound();
            }
            return View(checklist);
        }

        //
        // POST: /Checklist/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Checklist checklist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checklist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(checklist);
        }

        //
        // GET: /Checklist/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Checklist checklist = db.Checklists.Find(id);
            if (checklist == null)
            {
                return HttpNotFound();
            }
            return View(checklist);
        }

        //
        // POST: /Checklist/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Checklist checklist = db.Checklists.Find(id);
            db.Checklists.Remove(checklist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}