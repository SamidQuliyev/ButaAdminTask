using ButaAdminTask.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButaAdminTask.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public DashboardController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }



        public IActionResult Index()
        {
            var events = _db.Events.Where(e => e.EventDate > DateTime.Now ).OrderBy(x => x.EventDate).Take(3).ToList();
            return View(events);
        }

        public IActionResult GenderDistribution()
        {
            var maleCount = _db.Members.Where(m => m.Gender == "Kişi").Count();
            var femaleCount = _db.Members.Where(m => m.Gender == "Qadın").Count();

            return Json(new { male = maleCount, female = femaleCount });
        }

        public IActionResult UniversityMemberCount()
        {
            var universityCounts = _db.Members
                .GroupBy(m => m.University)
                .Select(g => new { University = g.Key, MemberCount = g.Count() })
                .ToList();

            return Json(universityCounts);
        }

        public IActionResult AgeMemberCount()
        {
            var ageCounts = _db.Members
                .GroupBy(m => m.Age)
                .OrderBy(g => g.Key)
                .Select(g => new { Age = g.Key, MemberCount = g.Count() })
                .ToList();

            return Json(ageCounts);
        }
    }
}