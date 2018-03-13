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
    public class LessonSectionController : Controller
    {
        private readonly IRepositoryAsync<Lesson> _lessonRepositoryAsync;
        private readonly IRepositoryAsync<LessonSection> _sectionRepositoryAsync;

        public LessonSectionController(IRepositoryAsync<Lesson> lessonRepositoryAsync, IRepositoryAsync<LessonSection> sectionRepositoryAsync)
        {
            _lessonRepositoryAsync = lessonRepositoryAsync;
            _sectionRepositoryAsync = sectionRepositoryAsync;
        }

        // GET: LessonSection
        public ActionResult Index()
        {
            return View();
        }

        // GET: LessonSection/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LessonSection/Create
        public async Task<ActionResult> Create(long id)
        {
            Lesson currentLesson = await _lessonRepositoryAsync.GetByIdAsync(id);

            LessonViewModel model = new LessonViewModel
            {
                Lesson = currentLesson,
                Section = new LessonSection
                {
                    User = currentLesson.User,
                    LessonId = currentLesson.Id
                }
            };

            return View(model);
        }

        // POST: LessonSection/Create
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

        // GET: LessonSection/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LessonSection/Edit/5
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

        // GET: LessonSection/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LessonSection/Delete/5
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