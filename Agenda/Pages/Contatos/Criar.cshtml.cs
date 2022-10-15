using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Data;
using Agenda.Models;
using Agenda.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Agenda.Pages.Contatos
{
    public class Criar : PageModel
    {
       private readonly Contexto _context;

        public Criar(Contexto context)
        {
            _context = context;
        }

        [BindProperty]
        public ListarContatos ViewModel { get; set; }

        public async Task<IActionResult> OnGet() {
            ViewModel = new ListarContatos {ListarCategoria = await _context.Categoria.ToListAsync(),
                Contato = new Contato()
            };

            return Page();
        }

        public async Task<IActionResult> OnPost() {
            if (!ModelState.IsValid) {
                ModelState.AddModelError(string.Empty, "Há um erro nas informações que você forneceu");
                return Page();
            }

            await _context.Contato.AddAsync(ViewModel.Contato);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}