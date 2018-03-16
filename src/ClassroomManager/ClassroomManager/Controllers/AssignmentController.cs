using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Entities;
using App.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly ILessonRepositoryAsync _lessonRepositoryAsync;
        private readonly IRepositoryAsync<Assignment> _assignmentRepositoryAsync;

        public AssignmentController(ILessonRepositoryAsync lessonRepositoryAsync, IRepositoryAsync<Assignment> assignmentRepositoryAsync)
        {
            _lessonRepositoryAsync = lessonRepositoryAsync;
            _assignmentRepositoryAsync = assignmentRepositoryAsync;
        }

        // GET: Assignment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Assignment/Details/5
        public async Task<ActionResult> Details(long id)
        {
            return View(await _lessonRepositoryAsync.GetByIdAsync(id));
        }

        // GET: Assignment/Create
        public async Task<ActionResult> Create(long id)
        {
            Lesson currentLesson = await _lessonRepositoryAsync.GetByIdAsync(id);
            Assignment newAssignment = new Assignment
            {
                LessonId = currentLesson.Id,
                User = currentLesson.User
            };
            return View(newAssignment);
        }

        // POST: Assignment/Create
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

        // GET: Assignment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Assignment/Edit/5
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

        // GET: Assignment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Assignment/Delete/5
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