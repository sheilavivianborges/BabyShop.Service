using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BabyShop.Models
{
    /// <summary>
    /// Classe de configuração do DbContext do ENtity Framework
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext( ) : base( "BabyShop" )
        {
            Database.SetInitializer<DatabaseContext>( null );
        }

        /// <summary>
        /// DbSet representando a tabela de clientes na base
        /// </summary>
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}