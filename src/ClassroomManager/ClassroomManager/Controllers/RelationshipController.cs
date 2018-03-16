using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class RelationshipController : Controller
    {
        // GET: Relationship
        public ActionResult Index()
        {
            return View();
        }

        // GET: Relationship/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Relationship/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Relationship/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Relationship/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Relationship/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Relationship/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Relationship/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}