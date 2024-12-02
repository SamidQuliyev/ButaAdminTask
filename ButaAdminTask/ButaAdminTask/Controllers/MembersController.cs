using ButaAdminTask.DAL;
using ButaAdminTask.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ButaAdminTask.Controllers
{
    public class MembersController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public MembersController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env; 
        }

        public IActionResult Index()
        {
            List<Members> members = _db.Members.Where(x => !x.IsDeactive).ToList();
            return View(members);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Members = await _db.Members.ToListAsync();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Members members)
        {
            
          

            if (members.FullName == null)
            {
                ModelState.AddModelError("FullName", "Zəhmət olmasa iştirakçı adını qeyd edin");
                return View();
            }
            if (members.Age == null)
            {
                ModelState.AddModelError("Age", "Zəhmət olmasa iştirakçının yaşını qeyd edin");
                return View();
            }
            if (members.Gender == null)
            {
                ModelState.AddModelError("Gender", "Zəhmət olmasa iştirakçının cinsini qeyd edin");
                return View();
            }

            if (members.Education == null)
            {
                ModelState.AddModelError("Education", "Zəhmət olmasa iştirakçının təhsilini qeyd edin");
                return View();
            }
            if (members.University == null)
            {
                ModelState.AddModelError("University", "Zəhmət olmasa iştirakçının universitetini qeyd edin");
                return View();
            }
            if (members.Profession == null)
            {
                ModelState.AddModelError("Profession", "Zəhmət olmasa iştirakçının ixtisasını qeyd edin");
                return View();
            }
            if (members.Course == null)
            {
                ModelState.AddModelError("Course", "Zəhmət olmasa iştirakçının kursunu qeyd edin");
                return View();
            }

         


            await _db.Members.AddAsync(members);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Members dbMembers = await _db.Members.FirstOrDefaultAsync(s => s.Id == id);
            if (dbMembers == null)
            {
                return BadRequest();
            }
            return View(dbMembers);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Members dbMembers = await _db.Members.FirstOrDefaultAsync(s => s.Id == id);
            if (dbMembers == null)
            {
                return Ok();
            }
            return View(dbMembers);
        }

        [HttpPost]
        
        public async Task<IActionResult> Update(int? id, Members members)
        {
            if (id == null)
            {
                return NotFound();
            }

            Members dbMembers = await _db.Members.FirstOrDefaultAsync(s => s.Id == id);
            if (dbMembers == null)
            {
                return Ok();
            }

         
            dbMembers.FullName = members.FullName;
            dbMembers.Age = members.Age;
            dbMembers.Gender = members.Gender;
            dbMembers.Education = members.Education;
            dbMembers.University = members.University;
            dbMembers.Profession = members.Profession;
            dbMembers.Course = members.Course;
            await _db.SaveChangesAsync();



            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Members dbMembers = await _db.Members.FirstOrDefaultAsync(s => s.Id == id);
            if (dbMembers == null)
            {
                return BadRequest();
            }
            return View(dbMembers);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Members dbMembers = await _db.Members.FirstOrDefaultAsync(s => s.Id == id);
            if (dbMembers == null)
            {
                return BadRequest();
            }
            dbMembers.IsDeactive = true;
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }

}
