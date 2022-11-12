using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
 * ************************************************************
 * ------------------------------------------------------------
 * 11-11-2022
 * Modelo y contexto de la Base de datos a migrar a SQL SERVER
 * Nelson Huenchuleo 
 * ------------------------------------------------------------
 * ************************************************************
 */

namespace CRUDVillanosApp.Controllers
{
    public class MyIndiminContext : DbContext
    {
        public MyIndiminContext(DbContextOptions<MyIndiminContext> options) : base(options)
        {

        }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Ciudadano> Ciudadanos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>().ToTable("Tarea");
            modelBuilder.Entity<Ciudadano>().ToTable("Ciudadano");
        }
    }
    public class Ciudadano
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        //public virtual ICollection<Tarea> Tarea { get; set; }
    }
    public class Tarea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Nombre { get; set; }        
        public int IdCiudadano { get; set; }
        [ForeignKey("IdCiudadano")]
        public virtual Ciudadano? Ciudadano { get; set; }
        public string dia { get; set; }

    }
}

