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
    public class Criar : PageModel
    {
        private readonly Contexto _context;

        public Criar(Contexto context)
        {
            _context = context;
        }

        [BindProperty]
        public Categoria Categoria { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() {
            if (!ModelState.IsValid)
 {
                ModelState.AddModelError(string.Empty, "Há um erro nos dados que você forneceu");
                return Page();
            }

            await _context.Categoria.AddAsync(Categoria);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }


    }
}