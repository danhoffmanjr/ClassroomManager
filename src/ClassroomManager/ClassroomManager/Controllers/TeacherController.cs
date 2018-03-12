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
            //TODO: add condition to send user to home index if email is null
            var user = await _teacherRepositoryAsync.GetByEmailAsync(email);
            return RedirectToAction("Dashboard", new { user = user.User });
        }

        // GET: Teacher/Dashboard/UserIdString(same as Identity Id)
        public async Task<ActionResult> Dashboard(string user)
        {
            var teacher = await _teacherRepositoryAsync.GetByUserAsync(user);

            return View(teacher);
        }

        // GET: Teacher/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _teacherRepositoryAsync.GetByIdAsync(id));
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Teacher profileToUpdate, IFormCollection collection)
        {
            try
            {
                await _teacherRepositoryAsync.UpdateAsync(profileToUpdate);

                return RedirectToAction("Dashboard", new { user = profileToUpdate.User });
            }
            catch
            {
                return View();
            }
        }
    }
}