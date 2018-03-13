using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Entities;
using App.Core.Interfaces;
using ClassroomManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonRepositoryAsync _lessonRepositoryAsync;

        public LessonController(ILessonRepositoryAsync lessonRepositoryAsync)
        {
            _lessonRepositoryAsync = lessonRepositoryAsync;
        }

        // GET: Lesson
        public async Task<ActionResult> Index(string user)
        {
            return View(await _lessonRepositoryAsync.ListByUserAsync(user));
        }

        // GET: Lesson/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lesson/Create
        public ActionResult Create(long teacherId, string userId, long courseId)
        {
            Lesson newLesson = new Lesson
            {
                TeacherId = teacherId,
                User = userId,
                CourseId = courseId
            };
            return View(newLesson);
        }

        // POST: Lesson/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Lesson data, IFormCollection collection)
        {
            try
            {
                Lesson newLesson = new Lesson
                {
                    User = data.User,
                    TeacherId = data.TeacherId,
                    CourseId = data.CourseId,
                    Title = data.Title,
                    Summary = data.Summary,
                    Subject = data.Subject,
                    PublishStatus = data.PublishStatus,
                    CreatedBy = data.User,
                    CreatedDate = DateTime.Now
                };
                await _lessonRepositoryAsync.AddAsync(newLesson);

                long newId = await _lessonRepositoryAsync.GetLastIdAsync();

                return RedirectToAction("Create", "LessonSection", new { id = newId});
            }
            catch
            {
                return View();
            }
        }

        // GET: Lesson/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lesson/Edit/5
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

        // GET: Lesson/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lesson/Delete/5
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