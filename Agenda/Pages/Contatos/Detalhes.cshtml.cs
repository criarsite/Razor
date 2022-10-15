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
    public class Detalhes : PageModel
    {
      private readonly Contexto _context;

        public Detalhes(Contexto context)
        {
            _context = context;
        }
[BindProperty]
        public Contato Contato { get; set; }

        public async Task OnGet(int id) {
            Contato = await _context.Contato.Where(c => c.Id == id).Include(c => c.Categoria).FirstOrDefaultAsync();
        }
    }
}