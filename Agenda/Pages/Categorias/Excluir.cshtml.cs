using Agenda.Data;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages
{
    public class Excluir : PageModel
    {

        private readonly Contexto _context;

        public Excluir(Contexto context)
        {
            _context = context;
        }

    [BindProperty]
        public Categoria Categoria { get; set; }

        public async Task OnGet(int id)
        {
            Categoria = await _context.Categoria.FindAsync(id);
        }

  

        public async Task<IActionResult> OnPostDelete(int id)
        {


            var categoriabd = await _context.Categoria.Where(e => e.Id == Categoria.Id).FirstAsync();
            // var categoriabd = _context.Categoria.Find(id);
            // var categoriabd = await _context.Categoria.FirstAsync(id);

            if (categoriabd is null)
            {
                return NotFound();
            }
            _context.Categoria.Remove(categoriabd);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}