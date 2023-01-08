using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplicationproiect.Data;
using WebApplicationproiect.Models;

namespace WebApplicationproiect.Pages.Angajati
{
    public class IndexModel : PageModel
    {
        private readonly WebApplicationproiect.Data.WebApplicationproiectContext _context;

        public IndexModel(WebApplicationproiect.Data.WebApplicationproiectContext context)
        {
            _context = context;
        }

        public IList<Angajat> Angajat { get;set; } = default!;
        public AngajatData AngajatD { get; set; }
        public int AngajatID { get; set; }
        public int ServiciuID { get; set; }
        public string SpecializareSort { get; set; }
        public string CurrentFilter { get; set; }

       

        public async Task OnGetAsync(int? id, int? serviciuID, string sortOrder, string searchString)
        {
            AngajatD = new AngajatData();

            SpecializareSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";

            CurrentFilter = searchString;

            AngajatD.Angajati = await _context.Angajat
            .Include(b => b.Specializare)
            .Include(b => b.AngajatServicii)
            .ThenInclude(b => b.Serviciu)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
               // AngajatD.Angajati = AngajatD.Angajati.Where(s => s.Specializare.Contains(searchString));
            }



                if (id != null)
            {
                AngajatID = id.Value;
                Angajat angajat = AngajatD.Angajati
                .Where(i => i.ID == id.Value).Single();
                AngajatD.Servicii = angajat.AngajatServicii.Select(s => s.Serviciu);
            }
            switch (sortOrder)
            {
                case "title_desc":
                    AngajatD.Angajati = AngajatD.Angajati.OrderByDescending(s =>
                   s.Specializare);
                    break;
             
            }
        }
    }
 
}
