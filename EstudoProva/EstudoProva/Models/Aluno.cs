using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoProva.Models
{
    public class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Registro Acadêmico (R.A)")]
        [MaxLength(18, ErrorMessage = "Este campo deve ser preenchido até 18 caracteres")]
        [Required(ErrorMessage = "O Campo R.A deve ser preenchido")]
        public string ra { get; set; }

        [Display(Name = "Nome do Aluno")]
        [MaxLength(40, ErrorMessage = "Este campo deve ser preenchido até 40 caracteres")]
        [Required(ErrorMessage = "O Campo Nome do Aluno deve ser preenchido")]
        public string nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "O Campo Data de Nascimento deve ser preenchido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime data_nasc { get; set; }

        [Display(Name = "CPF do Aluno")]
        [MaxLength(14, ErrorMessage = "Este campo deve ser preenchido até 14 caracteres")]
        public string cpf { get; set; }

        [Display(Name = "RG do Aluno")]
        [MaxLength(14, ErrorMessage = "Este campo deve ser preenchido até 14 caracteres")]
        public string rg { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Sexo deve ser preenchido")]
        public string sexo { get; set; }

        //Inicio Editado - foram adicionados os atributos abaixo para relacionameto
        public int cursoID { get; set; }

        public Curso curso { get; set; }


    }
}
