using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

        public IList<Specializare> Specializare { get; set; } = default!;
        public Models.NewFolder.SpecializareIndexData SpecializareData { get; set; }
        public int SpecializareID { get; set; }
        public int AngajatID { get; set; }
        public async Task OnGetAsync(int? id, int? angajatID)
        {
            SpecializareData = new Models.NewFolder.SpecializareIndexData();
            SpecializareData.Specializari = await _context.Specializare
            .Include(i => i.Angajati)
            .OrderBy(i => i.DenumireSpecializare)
            .ToListAsync();
            if (id != null)
            {
                SpecializareID = id.Value;
                Specializare specializare = SpecializareData.Specializari
                .Where(i => i.ID == id.Value).Single();
                SpecializareData.Angajati = specializare.Angajati;
            }
        }

        private async Task OnGetAsync1()
        {
            if (_context.Specializare != null)
            {
                Specializare = await _context.Specializare.ToListAsync();
            }
        }
    }
    }
