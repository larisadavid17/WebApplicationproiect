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
    }
}
