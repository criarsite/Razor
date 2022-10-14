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

namespace Agenda.Pages.Categorias
 {
     public class Editar : PageModel
 {
        private readonly Contexto _context;

         public Editar(Contexto context)
 {
            _context = context;
        }

        [BindProperty]
          public Categoria Categoria { get; set; }

        public async Task OnGet(int id) {
            Categoria = await _context.Categoria.FindAsync(id);
        }

         public async Task<IActionResult> OnPost() {
            var categoriabd = await _context.Categoria.Where(c => c.Id == Categoria.Id).FirstAsync();

            if (categoriabd is null) {
                return NotFound();
            }

            _context.Categoria.Remove(categoriabd);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
    }
