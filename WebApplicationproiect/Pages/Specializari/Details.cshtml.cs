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
    public class DetailsModel : PageModel
    {
        private readonly WebApplicationproiect.Data.WebApplicationproiectContext _context;

        public DetailsModel(WebApplicationproiect.Data.WebApplicationproiectContext context)
        {
            _context = context;
        }

      public Specializare Specializare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Specializare == null)
            {
                return NotFound();
            }

            var specializare = await _context.Specializare.FirstOrDefaultAsync(m => m.ID == id);
            if (specializare == null)
            {
                return NotFound();
            }
            else 
            {
                Specializare = specializare;
            }
            return Page();
        }
    }
}
