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
    public class Editar : PageModel
    {
          private readonly Contexto _context;

        public Editar(Contexto context)
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

            var buscarContato = await _context.Contato.Where(c => c.Id == ViewModel.Contato.Id).Include(c => c.Categoria).FirstOrDefaultAsync();

            buscarContato.Nome = ViewModel.Contato.Nome;
            buscarContato.Email = ViewModel.Contato.Email;
            buscarContato.Telefone = ViewModel.Contato.Telefone;
            buscarContato.Categoria = ViewModel.Contato.Categoria;
            buscarContato.DataCadastro = ViewModel.Contato.DataCadastro;

            _context.Entry(buscarContato).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}