using Cretu_Alexandru_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class GetPriceModel : PageModel
{
    private readonly Cretu_Alexandru_ProjectContext _context;
    public GetPriceModel(Cretu_Alexandru_ProjectContext context)
    {
        _context = context;
    }

    public JsonResult OnGet(int salaId, int echipamentId)
    {
        var sala = _context.Sala.FirstOrDefault(s => s.ID == salaId);
        var echipament = _context.Echipament.FirstOrDefault(e => e.ID == echipamentId);

        return new JsonResult(new { SalaPret = sala.Pret, EchipamentPret = echipament.Pret });
    }
}

