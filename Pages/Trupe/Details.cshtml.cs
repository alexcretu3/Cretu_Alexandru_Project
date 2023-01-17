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
    public class DetailsModel : PageModel
    {
        private readonly Cretu_Alexandru_Project.Data.Cretu_Alexandru_ProjectContext _context;

        public DetailsModel(Cretu_Alexandru_Project.Data.Cretu_Alexandru_ProjectContext context)
        {
            _context = context;
        }

      public Trupa Trupa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Trupa == null)
            {
                return NotFound();
            }
            
            var trupa = await _context.Trupa
                .Include(r => r.Reprezentant)
                .FirstOrDefaultAsync(m => m.ID == id);


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
    }
}
