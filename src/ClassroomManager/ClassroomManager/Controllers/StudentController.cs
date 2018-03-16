using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Entities;
using App.Core.Interfaces;
using App.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepositoryAsync<Student> _studentRepositoryAsync;
        private readonly ITeacherRepositoryAsync _teacherRepositoryAsync;

        public StudentController(IRepositoryAsync<Student> studentRepositoryAsync, ITeacherRepositoryAsync teacherRepositoryAsync)
        {
            _studentRepositoryAsync = studentRepositoryAsync;
            _teacherRepositoryAsync = teacherRepositoryAsync;
        }

        // GET: Student
        public async Task<ActionResult> Index(string user)
        {
            return View(await _teacherRepositoryAsync.GetByUserAsync(user));
        }

        // GET: Student/Details/5
        public ActionResult Profile(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Add(long teacherId, string userId)
        {
            StudentAddViewModel model = new StudentAddViewModel
            {
                Student = new Student
                {
                TeacherId = teacherId,
                User = userId,
                CreatedBy = userId,
                CreatedDate = DateTime.Now
                }
            };
            return View(model);
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(StudentAddViewModel newStudent, IFormCollection collection)
        {
            try
            {
                if (newStudent.StudentPic != null && newStudent.StudentPic.Length > 0)
                {
                    newStudent.Student.ImageUrl = newStudent.StudentPic.FileName.ToString();

                    var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot/images/students",
                            newStudent.StudentPic.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await newStudent.StudentPic.CopyToAsync(stream);
                    }

                    await _studentRepositoryAsync.AddAsync(newStudent.Student);
                }
                else
                {
                    newStudent.Student.ImageUrl = "fet.jpg";
                    await _studentRepositoryAsync.AddAsync(newStudent.Student);
                }

                return RedirectToAction("Index", "Student", new { user = newStudent.Student.User });
            }
            catch(Exception ex)
            {
                var errormsg = ex;
                return View(ex);
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
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