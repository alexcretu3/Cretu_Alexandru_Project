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
    public class IndexModel : PageModel
    {
        private readonly Cretu_Alexandru_Project.Data.Cretu_Alexandru_ProjectContext _context;

        public IndexModel(Cretu_Alexandru_Project.Data.Cretu_Alexandru_ProjectContext context)
        {
            _context = context;
        }

        public IList<Trupa> Trupa { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Trupa != null)
            {
                Trupa = await _context.Trupa
                    .Include(r => r.Reprezentant)
                    .ToListAsync();
            }
        }
    }
}
