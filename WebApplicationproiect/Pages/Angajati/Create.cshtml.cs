using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationproiect.Data;
using WebApplicationproiect.Models;

namespace WebApplicationproiect.Pages.Angajati
{
    public class CreateModel : AngajatServiciiPageModel
    {
        private readonly WebApplicationproiect.Data.WebApplicationproiectContext _context;

        public CreateModel(WebApplicationproiect.Data.WebApplicationproiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SpecializareID"] = new SelectList(_context.Set<Specializare>(), "ID",
"DenumireSpecializare");
            var angajat = new Angajat();
            angajat.AngajatServicii = new List<AngajatServiciu>();
            PopulateAssignedServiciuData(_context, angajat);
            return Page();
        }

        [BindProperty]
        public Angajat Angajat { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedServicii)
        {
            var newAngajat = new Angajat();
            if (selectedServicii != null)
            {
                newAngajat.AngajatServicii = new List<AngajatServiciu>();
                foreach (var cat in selectedServicii)
                {
                    var catToAdd = new AngajatServiciu
                    {
                        ServiciuID = int.Parse(cat)
                    };
                    newAngajat.AngajatServicii.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Angajat>(
            newAngajat,
            "Angajat",
            i => i.Nume,
            i => i.Experienta, i => i.Cursuri, i => i.SpecializareID))
            {
                _context.Angajat.Add(newAngajat);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedServiciuData(_context, newAngajat);
            return Page();
        }
    }
}




