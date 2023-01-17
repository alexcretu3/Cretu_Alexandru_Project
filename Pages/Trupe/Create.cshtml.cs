using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cretu_Alexandru_Project.Data;
using Cretu_Alexandru_Project.Models;
using System.Security.Policy;

namespace Cretu_Alexandru_Project.Pages.Trupe
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

            ViewData["ReprezentantID"] = new SelectList(_context.Reprezentant, "ID", "FullName");

            return Page();
        }

        [BindProperty]
        public Trupa Trupa { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Trupa.Add(Trupa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
