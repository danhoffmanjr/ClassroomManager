using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClassroomManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;

namespace ClassroomManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager) => _userManager = userManager;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string email)
        {
            if (string.IsNullOrEmpty(email) == true)
            {
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            return RedirectToAction("Setup", "Account", new { Email = email });
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> UserAlreadyExistsAsync(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);
            if (result != null)
            {
                return Json($"{email} is already in use.");
            }

            return Json(true);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
