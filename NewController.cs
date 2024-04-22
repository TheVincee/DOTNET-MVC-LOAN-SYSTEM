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
    public class NewController : Controller
    {
    
        private readonly UrsalutangananContext _context;
        public NewController(UrsalutangananContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.ClientInfos.ToList();
            return View(model);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(ClientInfo b)
        {
            _context.Add(b);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Update(int id)
        {
            var clientinfo = _context.ClientInfos.Where(q => q.Id == id).FirstOrDefault();
            return View(clientinfo);
        }

        [HttpPost]

        public IActionResult Update(ClientInfo b)
        { 
            _context.Update(b);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            var clientinfo = _context.ClientInfos.Where(q => q.Id == id).FirstOrDefault();
            _context.ClientInfos.Remove(clientinfo);
            _context.SaveChanges();
            
                return RedirectToAction("Index");
        }
    }
}