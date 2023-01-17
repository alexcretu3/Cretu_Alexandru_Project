using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Cretu_Alexandru_Project.Data;
using Cretu_Alexandru_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Globalization;

namespace Cretu_Alexandru_Project.Pages.Rezervari
{
    public class CreateModel : PageModel
    {
        private readonly Cretu_Alexandru_ProjectContext _context;

        public CreateModel(Cretu_Alexandru_ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; }

        public IActionResult OnGet()
        {
            ViewData["SalaID"] = new SelectList(_context.Sala, "ID", "NumeSala");
            ViewData["TrupaID"] = new SelectList(_context.Trupa, "ID", "NumeTrupa");
            ViewData["EchipamentId"] = new SelectList(_context.Echipament, "ID", "TipEchipament");
            return Page();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var sala = _context.Sala.FirstOrDefault(s => s.ID == Rezervare.SalaID);
                var equipment = _context.Echipament.FirstOrDefault(e => e.ID == Rezervare.EchipamentId);
                if (sala == null || equipment == null)
                {
                    ModelState.AddModelError("Pret", "Invalid Sala or Equipment selection");
                    return Page();
                }

                //Rezervare.OraInceput = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Rezervare.OraInceput, TimeZoneInfo.Local.Id, "UTC+01:00");
                Rezervare.Pret = (sala.Pret + equipment.Pret) * Rezervare.Timp;
                _context.Add(Rezervare);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            ViewData["SalaID"] = new SelectList(_context.Sala, "ID", "NumeSala");
            ViewData["TrupaID"] = new SelectList(_context.Trupa, "ID", "NumeTrupa");
            ViewData["EchipamentId"] = new SelectList(_context.Echipament, "ID", "TipEchipament");
            return Page();
        }

    }
}
