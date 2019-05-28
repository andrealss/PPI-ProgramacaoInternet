using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoProva.Models
{
    public class Curso
    {
        [Key]
        [Display(Name = "Identificador")]
        public int identificador { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Campo Nome deve ser preenchido")]
        public string nome { get; set; }

        [Display(Name = "Duração do Semestre")]
        [Required(ErrorMessage = "O Campo Duração do Semestre deve ser preenchido")]
        public int duracao_semestres { get; set; }

        [Display(Name = "Lista de Alunos")]
        public virtual ICollection<Aluno> ListaAlunos { get; set; }

        [Display(Name = "Relação de Disciplinas")]
        public ICollection<CursoDisciplina> ListaDisciplinas { get; set; }
    }
}
