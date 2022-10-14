using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Data;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Agenda.Pages.Categorias
 {
    public class Detalhes : PageModel
 {
          private readonly Contexto _context;

         public Detalhes(Contexto context)
 {
            _context = context;
        }

         [BindProperty]
          public Categoria Categoria { get; set; }

        public async Task OnGet(int id) {
            Categoria = await _context.Categoria.FindAsync(id);
        }
    }
}