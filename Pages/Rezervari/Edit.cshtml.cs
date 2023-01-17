using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cretu_Alexandru_Project.Data;
using Cretu_Alexandru_Project.Models;

namespace Cretu_Alexandru_Project.Pages.Rezervari
{
    public class EditModel : PageModel
    {
        private readonly Cretu_Alexandru_Project.Data.Cretu_Alexandru_ProjectContext _context;

        public EditModel(Cretu_Alexandru_Project.Data.Cretu_Alexandru_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rezervare == null)
            {
                return NotFound();
            }

            var rezervare = await _context.Rezervare.FirstOrDefaultAsync(m => m.ID == id);
            if (rezervare == null)
            {
                return NotFound();
            }
            Rezervare = rezervare;
            ViewData["SalaID"] = new SelectList(_context.Sala, "ID", "NumeSala");
            ViewData["TrupaID"] = new SelectList(_context.Trupa, "ID", "NumeTrupa");
            ViewData["ReprezentantID"] = new SelectList(_context.Reprezentant, "ID", "FullName");
            ViewData["EchipamentId"] = new SelectList(_context.Echipament, "ID", "TipEchipament");
            return Page();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Rezervare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezervareExists(Rezervare.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RezervareExists(int id)
        {
            return _context.Rezervare.Any(e => e.ID == id);
        }
    }
}
