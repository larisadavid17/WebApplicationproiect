using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationproiect.Data;
using WebApplicationproiect.Models;

namespace WebApplicationproiect.Pages.Specializari
{
    public class IndexModel : PageModel
    {
        private readonly WebApplicationproiect.Data.WebApplicationproiectContext _context;

        public IndexModel(WebApplicationproiect.Data.WebApplicationproiectContext context)
        {
            _context = context;
        }

        public IList<Specializare> Specializare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Specializare != null)
            {
                Specializare = await _context.Specializare.ToListAsync();
            }
        }
    }
}
