using ControleCustos.Dominio;
using ControleCustos.Dominio.UsuarioDominio.Classe;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ControleCustos.Repositorio
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("ControleCustos") { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Recurso> Recurso { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<ControleRecurso> ControleRecurso { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<RecursoCompartilhado>().ToTable("RecursoCompartilhado");
            modelBuilder.Entity<RecursoVinculadoProfissional>().ToTable("RecursoVinculadoProfissional");
            modelBuilder.Entity<Servico>().ToTable("Servico");
            base.OnModelCreating(modelBuilder);
        }
    }
}
