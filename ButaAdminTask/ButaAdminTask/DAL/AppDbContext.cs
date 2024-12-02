using ButaAdminTask.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ButaAdminTask.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Members> Members { get; set; }
        public DbSet<Events> Events { get; set; }


    }
}
