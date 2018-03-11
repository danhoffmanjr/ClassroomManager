using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Entities;
using App.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepositoryAsync _teacherRepositoryAsync;

        public TeacherController(ITeacherRepositoryAsync teacherRepositoryAsync)
        {
            _teacherRepositoryAsync = teacherRepositoryAsync;
        }


        // GET: Teacher
        public async Task<ActionResult> Index(string email)
        {
            var user = await _teacherRepositoryAsync.GetByEmailAsync(email);

            return RedirectToAction("Dashboard", new { user = user.User });
        }

        // GET: Teacher/Dashboard/#
        public async Task<ActionResult> Dashboard(string user)
        {
            var teacher = await _teacherRepositoryAsync.GetByUserAsync(user);

            return View(teacher);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
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

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Teacher/Edit/5
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

        // GET: Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teacher/Delete/5
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