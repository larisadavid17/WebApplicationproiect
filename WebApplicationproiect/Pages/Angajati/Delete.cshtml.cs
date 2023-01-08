using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationproiect.Data;
using WebApplicationproiect.Models;

namespace WebApplicationproiect.Pages.Angajati
{
    public class DeleteModel : PageModel
    {
        

        private readonly WebApplicationproiect.Data.WebApplicationproiectContext _context;

        public DeleteModel(WebApplicationproiect.Data.WebApplicationproiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Angajat Angajat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Angajat == null)
            {
                return NotFound();
            }

            var angajat = await _context.Angajat.FirstOrDefaultAsync(m => m.ID == id);

            if (angajat == null)
            {
                return NotFound();
            }
            else 
            {
                Angajat = angajat;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Angajat == null)
            {
                return NotFound();
            }
            var angajat = await _context.Angajat.FindAsync(id);

            if (angajat != null)
            {
                Angajat = angajat;
                _context.Angajat.Remove(Angajat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
