using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoProva.Models
{
    public class Disciplina
    {
        [Key]
        [Display(Name = "Identificador")]
        public int identificador { get; set; }

        [Display(Name = "Nome")]
        [MaxLength(50, ErrorMessage = "Este campo deve ser preenchido até 50 caracteres")]
        [Required(ErrorMessage = "O Campo Nome do Aluno deve ser preenchido")]
        public string nome { get; set; }
    }
}
