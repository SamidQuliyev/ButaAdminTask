using ButaAdminTask.DAL;
using ButaAdminTask.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButaAdminTask.Controllers
{
    public class EventsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public EventsController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Events> events = _db.Events.Where(x=>!x.IsDeactive).ToList();
            return View(events);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Events = await _db.Events.ToListAsync();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Events events)
        {
            await _db.Events.AddAsync(events);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Events dbEvents = await _db.Events.FirstOrDefaultAsync(s => s.Id == id);
            if (dbEvents == null)
            {
                return BadRequest();
            }
            return View(dbEvents);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Events dbEvents = await _db.Events.FirstOrDefaultAsync(s => s.Id == id);
            if (dbEvents == null)
            {
                return Ok();
            }
            return View(dbEvents);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int? id, Events events)
        {
            if (id == null)
            {
                return NotFound();
            }

            Events dbEvents = await _db.Events.FirstOrDefaultAsync(s => s.Id == id);
            if (dbEvents == null)
            {
                return Ok();
            }


            dbEvents.EventName = events.EventName;
            dbEvents.EventPlace = events.EventPlace;
            dbEvents.Duration = events.Duration;
            dbEvents.EventDate = events.EventDate;
            await _db.SaveChangesAsync();



            await _db.SaveChangesAsync();

           return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Events dbEvents = await _db.Events.FirstOrDefaultAsync(s => s.Id == id);
            if (dbEvents == null)
            {
                return BadRequest();
            }
            return View(dbEvents);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Events dbEvents = await _db.Events.FirstOrDefaultAsync(s => s.Id == id);
            if (dbEvents == null)
            {
                return BadRequest();
            }
            dbEvents.IsDeactive = true;
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }





    }
}
