using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly ILessonRepositoryAsync _lessonRepositoryAsync;
        private readonly IRepositoryAsync<LessonSection> _sectionRepositoryAsync;

        public LessonSectionController(ILessonRepositoryAsync lessonRepositoryAsync, IRepositoryAsync<LessonSection> sectionRepositoryAsync)
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

            if (currentLesson.Sections.Count > 0)
            {
                LessonViewModel model = new LessonViewModel
                {
                    Lesson = currentLesson,
                    Sections = currentLesson.Sections,
                    Section = new LessonSection
                    {
                        User = currentLesson.User,
                        LessonId = currentLesson.Id
                    }
                };

                return View(model);
            }
            else
            {
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
        }

        // POST: LessonSection/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LessonViewModel newSection,  IFormCollection collection)
        {
            try
            {
                LessonSection section = new LessonSection
                {
                    LessonId = newSection.Section.LessonId,
                    User = newSection.Section.User,
                    CreatedBy = newSection.Section.User,
                    CreatedDate = DateTime.Now,
                    SubTitle = newSection.Section.SubTitle,
                    Content = newSection.Section.Content,
                    PublishStatus = newSection.Section.PublishStatus,
                    ImageUrl = newSection.Section.FileToUpload.FileName.ToString()
                };

                if (newSection.Section.FileToUpload != null || newSection.Section.FileToUpload.Length > 0)
                {
                    var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot\blob",
                            newSection.Section.FileToUpload.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await newSection.Section.FileToUpload.CopyToAsync(stream);
                    }
                }

                await _sectionRepositoryAsync.AddAsync(section);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                var ErrorMsg = ex;
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