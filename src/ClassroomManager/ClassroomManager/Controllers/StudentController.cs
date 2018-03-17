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
        private readonly IStudentRepositoryAsync _studentRepositoryAsync;
        private readonly ITeacherRepositoryAsync _teacherRepositoryAsync;

        public StudentController(IStudentRepositoryAsync studentRepositoryAsync, ITeacherRepositoryAsync teacherRepositoryAsync)
        {
            _studentRepositoryAsync = studentRepositoryAsync;
            _teacherRepositoryAsync = teacherRepositoryAsync;
        }

        // GET: Student
        public async Task<ActionResult> Index(string user)
        {
            Teacher teacherData = await _teacherRepositoryAsync.GetByUserAsync(user);
            //Somehow adding this List of Students query will change the teacherData query to include StudentLessons (grandchild data), without this, all StudentLessons for Students is null.
            List<Student> Students = await _studentRepositoryAsync.ListByUserAsync(user);
            return View(teacherData);
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
                    //Upload file if it doesn't already exist on server
                    newStudent.Student.ImageUrl = newStudent.StudentPic.FileName.ToString();

                    var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot/images/students",
                            newStudent.StudentPic.FileName);

                    if (!System.IO.File.Exists(path))
                    {
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await newStudent.StudentPic.CopyToAsync(stream);
                        }
                    }

                    await _studentRepositoryAsync.AddAsync(newStudent.Student);
                }
                else
                {
                    newStudent.Student.ImageUrl = "fet.jpg"; // sets default Profile picture
                    await _studentRepositoryAsync.AddAsync(newStudent.Student);
                }

                return RedirectToAction("Index", new { user = newStudent.Student.User });
            }
            catch(Exception ex)
            {
                var errormsg = ex;
                return View(ex);
            }
        }

        // GET: Student/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Student student = await _studentRepositoryAsync.GetByIdAsync(id);

            StudentAddViewModel model = new StudentAddViewModel
            {
                Student = student
            };
            return View(model);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(StudentAddViewModel updateStudent, IFormCollection collection)
        {
            try
            {
                if (updateStudent.StudentPic != null && updateStudent.StudentPic.Length > 0)
                {
                    updateStudent.Student.ImageUrl = updateStudent.StudentPic.FileName.ToString();

                    var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot/images/students",
                            updateStudent.StudentPic.FileName);

                    //Upload file if it doesn't already exist on server
                    if (!System.IO.File.Exists(path))
                    {
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await updateStudent.StudentPic.CopyToAsync(stream);
                        }
                    }

                    await _studentRepositoryAsync.UpdateAsync(updateStudent.Student);
                }
                else
                {
                    await _studentRepositoryAsync.UpdateAsync(updateStudent.Student);
                }

                return RedirectToAction("Index", new { user = updateStudent.Student.User });
            }
            catch (Exception ex)
            {
                var errorMsg = ex.Message;
                return View(errorMsg);
            }
        }

        // GET: Student/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            Student student = await _studentRepositoryAsync.GetByIdAsync(id);

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Student toDelete, IFormCollection collection)
        {
            try
            {
                Student studentToDelete = await _studentRepositoryAsync.GetByIdAsync(toDelete.Id);

                await _studentRepositoryAsync.DeleteAsync(studentToDelete);

                return RedirectToAction("Index", new { user = studentToDelete.User });
            }
            catch(Exception ex)
            {
                var errorMsg = ex.Message;
                return View(errorMsg);
            }
        }
    }
}