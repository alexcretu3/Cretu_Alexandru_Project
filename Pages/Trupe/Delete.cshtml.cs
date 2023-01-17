using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cretu_Alexandru_Project.Data;
using Cretu_Alexandru_Project.Models;

namespace Cretu_Alexandru_Project.Pages.Trupe
{
    public class DeleteModel : PageModel
    {
        private readonly Cretu_Alexandru_Project.Data.Cretu_Alexandru_ProjectContext _context;

        public DeleteModel(Cretu_Alexandru_Project.Data.Cretu_Alexandru_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Trupa Trupa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Trupa == null)
            {
                return NotFound();
            }

            var trupa = await _context.Trupa.FirstOrDefaultAsync(m => m.ID == id);

            if (trupa == null)
            {
                return NotFound();
            }
            else 
            {
                Trupa = trupa;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Trupa == null)
            {
                return NotFound();
            }
            var trupa = await _context.Trupa.FindAsync(id);

            if (trupa != null)
            {
                Trupa = trupa;
                _context.Trupa.Remove(Trupa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
