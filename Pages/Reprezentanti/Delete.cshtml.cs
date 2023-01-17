using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cretu_Alexandru_Project.Data;
using Cretu_Alexandru_Project.Models;

namespace Cretu_Alexandru_Project.Pages.Reprezentanti
{
    public class DeleteModel : PageModel
    {
        private readonly Cretu_Alexandru_Project.Data.Cretu_Alexandru_ProjectContext _context;

        public DeleteModel(Cretu_Alexandru_Project.Data.Cretu_Alexandru_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Reprezentant Reprezentant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Reprezentant == null)
            {
                return NotFound();
            }

            var reprezentant = await _context.Reprezentant.FirstOrDefaultAsync(m => m.ID == id);

            if (reprezentant == null)
            {
                return NotFound();
            }
            else 
            {
                Reprezentant = reprezentant;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Reprezentant == null)
            {
                return NotFound();
            }
            var reprezentant = await _context.Reprezentant.FindAsync(id);

            if (reprezentant != null)
            {
                Reprezentant = reprezentant;
                _context.Reprezentant.Remove(Reprezentant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
