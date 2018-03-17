﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Entities;
using App.Core.Interfaces;
using App.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class RelationshipController : Controller
    {
        private readonly ILessonRepositoryAsync _lessonRepositoryAsync;
        private readonly ITeacherRepositoryAsync _teacherRepositoryAsync;
        private readonly IStudentRepositoryAsync _studentRepositoryAsync;
        private readonly IRelationshipRepositoryAsync _relationshipRepositoryAsync;

        public RelationshipController(ILessonRepositoryAsync lessonRepositoryAsync, 
            ITeacherRepositoryAsync teacherRepositoryAsync, 
            IStudentRepositoryAsync studentRepositoryAsync,
            IRelationshipRepositoryAsync relationshipRepositoryAsync)
        {
            _lessonRepositoryAsync = lessonRepositoryAsync;
            _teacherRepositoryAsync = teacherRepositoryAsync;
            _studentRepositoryAsync = studentRepositoryAsync;
            _relationshipRepositoryAsync = relationshipRepositoryAsync;
        }

        // GET: Relationship
        public ActionResult Index()
        {
            return View();
        }

        // GET: Relationship/StudentLessons
        public async Task<ActionResult> StudentLessons(string user, long id)
        {
            Teacher teacher = await _teacherRepositoryAsync.GetByUserAsync(user);
            Student student = await _studentRepositoryAsync.GetByIdAsync(id);
            List<Lesson> lessons = teacher.Lessons;

            RelationshipViewModel model = new RelationshipViewModel
            {
                Teacher = teacher,
                Student = student
            };

            return View(model);
        }

        // POST: Relationship/StudentLessons
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> StudentLessons(RelationshipViewModel model, IFormCollection collection)
        {
            try
            {
                List<StudentLesson> idList = model.Student.StudentLessons.ToList();
                foreach (var row in model.Student.StudentLessons)
                {
                    
                }

                _relationshipRepositoryAsync.AddRangeAsync(idList);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Relationship/CourseLessons
        public async Task<ActionResult> CourseLessons(string user)
        {
            return View(await _teacherRepositoryAsync.GetByUserAsync(user));
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