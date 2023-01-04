using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationproiect.Data;
using WebApplicationproiect.Models;

namespace WebApplicationproiect.Pages.Specializari
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
            return Page();
        }

        [BindProperty]
        public Specializare Specializare { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Specializare.Add(Specializare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
