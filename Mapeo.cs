using System.Data.Entity;
using Utilitarios;


namespace Data
{
    /// <summary>
    /// Descripción breve de Mapeo
    /// </summary>
    public class Mapeo : DbContext
    {
        static Mapeo()
        {
            Database.SetInitializer<Mapeo>(null);
        }
        private readonly string schema;

        public Mapeo()
            : base("name=postgres")
        {

        }

        public DbSet<UUsuario> usuario { get; set; }
        public DbSet<UAplicacion> aplicacion { get; set; }
        public DbSet<UToken> token { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema(this.schema);

            base.OnModelCreating(builder);
        }
    }
}