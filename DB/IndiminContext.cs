using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class IndiminContext : DbContext
    {
        public IndiminContext(DbContextOptions<IndiminContext> options):base (options)
        {

        }
        //le decimos al EF que habran las siguientes tablas
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Ciudadano> Ciudadanos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>().ToTable("Tarea");
            modelBuilder.Entity<Ciudadano>().ToTable("Ciudadano");
        }
    }
}