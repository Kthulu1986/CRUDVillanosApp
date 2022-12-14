using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Tarea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Nombre { get; set; }
        public int IdCiudadano { get; set; }

        [ForeignKey("IdCiudadano")]
        public virtual Ciudadano Ciudadano { get; set; }

    }
}
