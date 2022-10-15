using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Data;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Agenda.Pages.Contatos
{
    public class Excluir : PageModel
    {
        private readonly Contexto _context;

        public Excluir(Contexto context)
        {
            _context = context;
        }
[BindProperty]
        public Contato Contato { get; set; }

        public async Task OnGet(int id) {
            Contato = await _context.Contato.Where(c => c.Id == id).Include(c => c.Categoria).FirstOrDefaultAsync();
        }

        public async Task<IActionResult> OnPost() {
            var buscarContato = await _context.Contato.Where(c => c.Id == Contato.Id).Include(c => c.Categoria).FirstOrDefaultAsync();

            if (buscarContato is null) {
                return NotFound();
            }

            _context.Contato.Remove(buscarContato);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}