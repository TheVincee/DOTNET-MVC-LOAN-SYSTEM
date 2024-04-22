using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BKK.Entities;

namespace BKK.Controllers
{
    public class NewedController : Controller
    {
        private readonly UrsalutangananContext _context ;

        public NewedController(UrsalutangananContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.UserTypes.ToList(); 
            return View(model);
        }
      
        
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["UserTypes"] = _context.UserTypes.ToList();
            return View();
        }

        [HttpPost]

            public IActionResult Create(UserType u)
            {
                _context.UserTypes.Add(u);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }

       
            public IActionResult Update(int id){
            var user = _context.UserTypes.Where(q => q.Id == id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public IActionResult Update(UserType u){
            _context.UserTypes.Update(u);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

       
        [HttpGet]
            public IActionResult Delete(int id){
            var user = _context.UserTypes.Where(q => q.Id == id).FirstOrDefault();
            _context.UserTypes.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}