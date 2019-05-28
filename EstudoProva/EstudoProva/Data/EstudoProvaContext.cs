using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EstudoProva.Models;

namespace EstudoProva.Models
{
    public class EstudoProvaContext : DbContext
    {
        public EstudoProvaContext (DbContextOptions<EstudoProvaContext> options)
            : base(options)
        {
        }

        public DbSet<EstudoProva.Models.Aluno> Aluno { get; set; }

        public DbSet<EstudoProva.Models.Curso> Curso { get; set; }

        public DbSet<EstudoProva.Models.Disciplina> Disciplina { get; set; }

        public DbSet<EstudoProva.Models.CursoDisciplina> CursoDisciplina { get; set; }
    }
}
