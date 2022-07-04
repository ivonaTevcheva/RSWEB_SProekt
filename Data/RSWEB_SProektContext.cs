using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RSWEB_SProekt.Areas.Identity.Data;
using RSWEB_SProekt.Models;

namespace RSWEB_SProekt.Data
{
    public class RSWEB_SProektContext : IdentityDbContext<RSWEB_SProektUser>
    {
        public RSWEB_SProektContext (DbContextOptions<RSWEB_SProektContext> options)
            : base(options)
        {
        }

        public DbSet<RSWEB_SProekt.Models.Author>? Author { get; set; }

        public DbSet<RSWEB_SProekt.Models.Book>? Book { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
