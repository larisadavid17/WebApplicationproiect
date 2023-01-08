using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationproiect.Data;
using WebApplicationproiect.Models;

namespace WebApplicationproiect.Pages.Angajati
{
    public class EditModel : AngajatServiciiPageModel
    {
      

        private readonly WebApplicationproiect.Data.WebApplicationproiectContext _context;

        public EditModel(WebApplicationproiect.Data.WebApplicationproiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Angajat Angajat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Angajat == null)
            {
                return NotFound();
            }
            Angajat = await _context.Angajat
 .Include(b => b.Specializare)
 .Include(b => b.AngajatServicii).ThenInclude(b => b.Serviciu)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);
            if (Angajat == null)
            {
                return NotFound();
            }
            var angajat = await _context.Angajat.FirstOrDefaultAsync(m => m.ID == id);
            if (angajat == null)
            {
                return NotFound();
            }
            PopulateAssignedServiciuData(_context, Angajat);
            Angajat = angajat;
            ViewData["SpecializareID"] = new SelectList(_context.Set<Specializare>(), "ID",
"SpecializareName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedServicii)
        {
            if (id == null)
            {
                return NotFound();
            }
            var angajatToUpdate = await _context.Angajat
 .Include(i => i.Specializare)
 .Include(i => i.AngajatServicii)
 .ThenInclude(i => i.Serviciu)
 .FirstOrDefaultAsync(s => s.ID == id);
            if (angajatToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Angajat>(
 angajatToUpdate,
 "Angajat",
 i => i.Nume,
 i => i.Experienta, i => i.Cursuri, i => i.SpecializareID))
            {
                UpdateAngajatServicii(_context, selectedServicii, angajatToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateAngajatServicii(_context, selectedServicii, angajatToUpdate);
            PopulateAssignedServiciuData(_context, angajatToUpdate);
            return Page();
        }
    }
}





       
