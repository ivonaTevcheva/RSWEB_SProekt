using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RSWEB_SProekt.Models;

namespace RSWEB_SProekt.Data
{
    public class RSWEB_SProektContext : DbContext
    {
        public RSWEB_SProektContext (DbContextOptions<RSWEB_SProektContext> options)
            : base(options)
        {
        }

        public DbSet<RSWEB_SProekt.Models.Author>? Author { get; set; }

        public DbSet<RSWEB_SProekt.Models.Book>? Book { get; set; }
    }
}
