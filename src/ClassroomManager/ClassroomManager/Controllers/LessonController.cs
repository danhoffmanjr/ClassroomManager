using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Entities;
using App.Core.Interfaces;
using App.Web.Models;
using ClassroomManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonRepositoryAsync _lessonRepositoryAsync;
        private readonly IRepositoryAsync<LessonSection> _sectionRepositoryAsync;

        public LessonController(ILessonRepositoryAsync lessonRepositoryAsync, IRepositoryAsync<LessonSection> sectionRepositoryAsync)
        {
            _lessonRepositoryAsync = lessonRepositoryAsync;
            _sectionRepositoryAsync = sectionRepositoryAsync;
        }

        // GET: Lesson
        public async Task<ActionResult> Index(string user)
        {
            List<Lesson> LessonsList = await _lessonRepositoryAsync.ListByUserAsync(user);
            if (LessonsList == null || LessonsList.Count <= 0)
            {
                LessonsIndexViewModel model = new LessonsIndexViewModel
                {
                    Lesson = new Lesson
                    {
                        User = user
                    },
                    Lessons = LessonsList
                };

                return View(model);
            }
            else
            {
                LessonsIndexViewModel model = new LessonsIndexViewModel
                {
                    Lesson = LessonsList[0],
                    Lessons = LessonsList
                };

                return View(model);
            }
        }

        // GET: Lesson/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _lessonRepositoryAsync.GetByIdAsync(id));
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
                    CourseId = data.CourseId == 0 ? null : data.CourseId,
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
        public async Task<ActionResult> Edit(long id)
        {
            return View(await _lessonRepositoryAsync.GetByIdAsync(id));
        }

        // POST: Lesson/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Lesson updatedLesson, IFormCollection collection)
        {
            try
            {

                await _lessonRepositoryAsync.UpdateAsync(updatedLesson);
                foreach (var section in updatedLesson.Sections)
                {
                    await _sectionRepositoryAsync.UpdateAsync(section);
                }

                return RedirectToAction("Details", "Lesson", new { id = updatedLesson.Id });
            }
            catch(Exception ex)
            {
                var errorMsg = ex;
                return View();
            }
        }

        // GET: Lesson/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            return View(await _lessonRepositoryAsync.GetByIdAsync(id));
        }

        // POST: Lesson/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Lesson toDelete, IFormCollection collection)
        {
            try
            {
                var lesson = await _lessonRepositoryAsync.GetByIdAsync(toDelete.Id);
                await _lessonRepositoryAsync.DeleteAsync(lesson);

                return RedirectToAction("Index", new { user = lesson.User });
            }
            catch(Exception ex)
            {
                var ErrorMsg = ex;
                return View();
            }
        }
    }
}