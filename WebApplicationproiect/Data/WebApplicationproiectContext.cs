using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationproiect.Models;

namespace WebApplicationproiect.Data
{
    public class WebApplicationproiectContext : DbContext
    {
        public WebApplicationproiectContext (DbContextOptions<WebApplicationproiectContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationproiect.Models.Angajat> Angajat { get; set; } = default!;

        public DbSet<WebApplicationproiect.Models.Specializare> Specializare { get; set; }

        public DbSet<WebApplicationproiect.Models.Serviciu> Serviciu { get; set; }

        public DbSet<WebApplicationproiect.Models.Client> Client { get; set; }

        public DbSet<WebApplicationproiect.Models.Programare> Programare { get; set; }
    }
}
