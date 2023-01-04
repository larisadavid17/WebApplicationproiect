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
        public async Task OnGetAsync(int? id, int? serviciuID)
        {
            AngajatD = new AngajatData();

            AngajatD.Angajati = await _context.Angajat
            .Include(b => b.Specializare)
            .Include(b => b.AngajatServicii)
            .ThenInclude(b => b.Serviciu)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();
            if (id != null)
            {
                AngajatID = id.Value;
                Angajat angajat = AngajatD.Angajati
                .Where(i => i.ID == id.Value).Single();
                AngajatD.Servicii = angajat.AngajatServicii.Select(s => s.Serviciu);
            }
        }
    }
 
}
