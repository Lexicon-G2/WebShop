using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppForWebshop.Data;
using WebAppForWebshop.Models;

namespace WebAppForWebshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly  ApplicationDbContext db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Products()
        {
           
            return View();
        }

        public IActionResult User()
        {//LIST ALL USERS
            ApplicationUser model = new ApplicationUser();
            // trying to place IdentityUser -> applicationUser
            model.userList = db.Users.ToList();
            return View("User", model);
        }

        public IActionResult ManageUser(string id)
        {
            var user = db.Users.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.Test = user.Id +" - " +user.UserName;
            return View("manageUser", ViewBag);
        }

        [HttpPost]
        public IActionResult AddUser()
        {//ADD SPECIFIC USER
            return View();
        }
        [HttpPost]
        public IActionResult RemoveUser()
        {//REMOVE SPECIFIC USER
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
