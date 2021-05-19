using BugTracker.Models;
using BugTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class SolveController : Controller
    {
        private BugsContext db;
        public SolveController(BugsContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            //var elements = new List<Improvement>(db.Improvements.Include(s => s.Statuses).ToList());
            return View(await db.Improvements.ToListAsync());
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Improvement improvement, string statuses)
        {
            var _imp = improvement;
            //_imp.Statuses.Clear();
            //получаем список всех статусов в БД для сравнения и обновления
            if (!(statuses == null))
            {
                var existingStatuses = db.Statuses.Select(s => s.Name);
                char[] delimiterChars = { ' ', ',', '.', ':', ';' };
                foreach (string ss in statuses.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries))
                {
                    //если указанный статус в БД уже есть, то связываем задачу и статус
                    if (existingStatuses.Contains(ss))
                    {
                        Status _st = db.Statuses.Single(s => s.Name == ss);
                        _imp.Statuses.Add(_st);
                        //выбрать статус в бд. добавить к задаче. 
                    }
                    //иначе создаем статус, записываем в бд, связываем с задачей.
                    else
                    {
                        Status _st = new Status { Name = ss };
                        db.Statuses.Add(_st);
                        db.SaveChanges();
                        _imp.Statuses.Add(_st);
                        
                        //создать объект статус. добавить в бд. добавить к задаче. обновить бд

                    }

                }
            }
            db.Improvements.Add(_imp);
            
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}