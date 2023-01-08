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

namespace WebApplicationproiect.Pages.Programari
{
    public class CreateModel : PageModel
    {
        private readonly WebApplicationproiect.Data.WebApplicationproiectContext _context;

        public CreateModel(WebApplicationproiect.Data.WebApplicationproiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var angajatList = _context.Angajat
      .Include(b => b.Specializare)
      .Select(x => new
 {
     x.ID,
     AngajatFullName = x.Nume + " - " + x.Specializare.DenumireSpecializare + " " 
 });

            ViewData["AngajatID"] = new SelectList(angajatList, "ID", "ID", "AngajatFullName");
        ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
