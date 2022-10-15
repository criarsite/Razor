using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public class Contato
    {
          [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O {0} do contato é obrigatorio")]
        [StringLength(50, ErrorMessage = "O{0} deve estar entre  {2} e {1} caracteres", MinimumLength = 4)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O {0} do contato é obrigatorio")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O {0} do contato é obrigatorio")]
        [Phone]
        [Display(Name = "Numero do telefone")]
        public string Telefone { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data do Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Required]
         public int CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        public Categoria Categorias { get; set; }
    
    }
}