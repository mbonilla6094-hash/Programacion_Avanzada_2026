using Microsoft.EntityFrameworkCore;
using PredictorTarifa.Entidades;

namespace PredictorTarifa.Datos
{
    // Contexto de Entity Framework Core - Representa la base de datos
    public class ContextoBD : DbContext
    {
        // Tabla de viajes en SQL Server
        public DbSet<Viaje> Viajes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opciones)
        {
            // Conexion a SQL Server Express local con autenticacion de Windows
            opciones.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=PredictorTarifaDB;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelCreador)
        {
            // Configuracion de la tabla Viajes
            modelCreador.Entity<Viaje>(entidad =>
            {
                entidad.HasKey(v => v.Id);
                entidad.Property(v => v.Empresa).HasMaxLength(10).IsRequired();
                entidad.Property(v => v.TipoPago).HasMaxLength(5).IsRequired();
                entidad.Property(v => v.FechaRegistro).HasDefaultValueSql("GETDATE()");
                entidad.ToTable("Viajes");
            });
        }
    }
}
