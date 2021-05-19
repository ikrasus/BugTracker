using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class HomeController : Controller
    {

        private BugsContext db;
        public HomeController(BugsContext context)
        {
            db = context;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await db.Bugs.ToListAsync());
        }
        public IActionResult Create()
        {         
           
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Bug bug)
        {
            db.Bugs.Add(bug);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Bug bug = await db.Bugs.FirstOrDefaultAsync(p => p.Id == id);
                if (bug != null)
                    return View(bug);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Bug bug)
        {
            db.Bugs.Update(bug);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Bug bug = await db.Bugs.FirstOrDefaultAsync(b => b.Id == id);
                if (bug != null)
                    return View(bug);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Bug bug = await db.Bugs.FirstOrDefaultAsync(b => b.Id == id);
                if (bug != null)
                {
                    db.Bugs.Remove(bug);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
