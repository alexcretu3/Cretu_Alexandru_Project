using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cretu_Alexandru_Project.Data;
using Cretu_Alexandru_Project.Models;

namespace Cretu_Alexandru_Project.Pages.Echipamente
{
    public class DetailsModel : PageModel
    {
        private readonly Cretu_Alexandru_Project.Data.Cretu_Alexandru_ProjectContext _context;

        public DetailsModel(Cretu_Alexandru_Project.Data.Cretu_Alexandru_ProjectContext context)
        {
            _context = context;
        }

      public Echipament Echipament { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Echipament == null)
            {
                return NotFound();
            }

            var echipament = await _context.Echipament.FirstOrDefaultAsync(m => m.ID == id);
            if (echipament == null)
            {
                return NotFound();
            }
            else 
            {
                Echipament = echipament;
            }
            return Page();
        }
    }
}
