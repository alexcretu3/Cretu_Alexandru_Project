using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cretu_Alexandru_Project.Data;
using Cretu_Alexandru_Project.Models;

namespace Cretu_Alexandru_Project.Pages.Reprezentanti
{
    public class CreateModel : PageModel
    {
        private readonly Cretu_Alexandru_Project.Data.Cretu_Alexandru_ProjectContext _context;

        public CreateModel(Cretu_Alexandru_Project.Data.Cretu_Alexandru_ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TrupaID"] = new SelectList(_context.Set<Trupa>(), "ID", "ID");
                return Page();
        }

        [BindProperty]
        public Reprezentant Reprezentant { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reprezentant.Add(Reprezentant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
