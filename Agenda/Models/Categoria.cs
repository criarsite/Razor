using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Models
{
   public class Categoria
    {
        [Key]    // DataAnottation  informa que essa seja fa Primary Key
        public int Id {get; set;}
        [Required(ErrorMessage ="Campo Obrigatorio")]
        [StringLength(15, ErrorMessage ="{0} O nome deve conter entre {2} e {1}", MinimumLength = 4)]
        public string Nome {get; set;}

        [DataType(DataType.Date)]
        [Display(Name ="Data do cadastro")]
        public DateTime DataCadastro {get; set;}
    }
}