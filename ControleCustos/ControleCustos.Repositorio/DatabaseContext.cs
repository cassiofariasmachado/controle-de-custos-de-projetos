using ControleCustos.Dominio.UsuarioDominio.Classe;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ControleCustos.Repositorio
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("ControleCustos")
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
