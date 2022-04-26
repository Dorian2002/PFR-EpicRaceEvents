using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using App.ViewModels;
using App.Models;
using App.Data;

namespace App.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AppDbContext _dbContext;
        public RegisterController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: Register
        public ActionResult Index()
        {
            return View("Index");
        }
        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Register user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Pilot newPilot = new()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        BirthDate = user.BirthDate,
                        Mail = user.Mail,
                        Password = user.Password
                    };
                    _dbContext.Pilots.Add(newPilot);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                return View("Index");
            }
            catch
            {
                return View("Index");
            }
        }
    }
}