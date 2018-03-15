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
    public class CourseController : Controller
    {
        private readonly IRepositoryAsync<Course> _courseRepositoryAsync;

        public CourseController(IRepositoryAsync<Course> courseRepositoryAsync)
        {
            _courseRepositoryAsync = courseRepositoryAsync;
        }

        // GET: Course/Create
        public ActionResult Create(long teacherId, string userId)
        {
            Course newCourse = new Course
            {
                TeacherId = teacherId,
                User = userId,
                CreatedBy = userId,
                CreatedDate = DateTime.Now
            };
            return View(newCourse);
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Course newCourse, IFormCollection collection)
        {
            try
            {
                var addCourse = await _courseRepositoryAsync.AddAsync(newCourse);

                return RedirectToAction("Dashboard", "Teacher", new { user = newCourse.User });
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _courseRepositoryAsync.GetByIdAsync(id));
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Course courseToUpdate, IFormCollection collection)
        {
            try
            {
                await _courseRepositoryAsync.UpdateAsync(courseToUpdate);

                return RedirectToAction("Dashboard", "Teacher", new { user = courseToUpdate.User });
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _courseRepositoryAsync.GetByIdAsync(id));
        }

        // POST: Course/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Course courseToDelete, IFormCollection collection)
        {
            try
            {
                var course = await _courseRepositoryAsync.GetByIdAsync(courseToDelete.Id);
                await _courseRepositoryAsync.DeleteAsync(course);

                return RedirectToAction("Dashboard", "Teacher", new { user = course.User });
            }
            catch(Exception ex)
            {
                var errorMsg = ex;
                return View(courseToDelete);
            }
        }
    }
}