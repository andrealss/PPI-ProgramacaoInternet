using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoProva.Models
{
    public class CursoDisciplina
    {
        [Key]
        public int ID { get; set; }

        public int cursoID { get; set; }

        [Display(Name = "Curso")]
        public Curso curso { get; set; }

        public int disciplinaID { get; set; }

        [Display(Name = "Disciplina")]
        public Disciplina disciplina { get; set; }
    }
}
