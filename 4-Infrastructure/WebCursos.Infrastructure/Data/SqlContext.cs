using Microsoft.EntityFrameworkCore;
using WebCursos.Domain.Entities;

namespace WebCursos.Infrastructure.Data
{
    public class SqlContext : DbContext
    {

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Auth> Auths { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<AlunoTurma> AlunoTurmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlContext).Assembly);

            base.OnModelCreating(modelBuilder);
            
        }

    }

}

