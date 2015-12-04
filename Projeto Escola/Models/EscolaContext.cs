using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Escola.Models
{
    public class EscolaContext : DbContext
    {

         
        public EscolaContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Materia> Materias { get; set; }

        public DbSet<Professor> Professores { get; set; }

        public System.Data.Entity.DbSet<Escola.Models.MateriaLecionada> MateriaLecionadas { get; set; }

        public System.Data.Entity.DbSet<Escola.Models.Matricula> Matriculas { get; set; }

    }
}