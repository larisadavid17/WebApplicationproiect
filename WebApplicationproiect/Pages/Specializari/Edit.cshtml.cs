using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationproiect.Data;
using WebApplicationproiect.Models;

namespace WebApplicationproiect.Pages.Specializari
{
    public class EditModel : PageModel
    {
        private readonly WebApplicationproiect.Data.WebApplicationproiectContext _context;

        public EditModel(WebApplicationproiect.Data.WebApplicationproiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Specializare Specializare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Specializare == null)
            {
                return NotFound();
            }

            var specializare =  await _context.Specializare.FirstOrDefaultAsync(m => m.ID == id);
            if (specializare == null)
            {
                return NotFound();
            }
            Specializare = specializare;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Specializare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecializareExists(Specializare.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SpecializareExists(int id)
        {
          return _context.Specializare.Any(e => e.ID == id);
        }
    }
}
