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
    public class Index : PageModel
    {
       private readonly Contexto _context;

        public Index(Contexto context)
        {
            _context = context;
        }

        public IEnumerable<Contato> Contatos { get; set; }

        public async Task OnGet() 
        {
            Contatos = await _context.Contato.ToListAsync();
        }
    
    }
}