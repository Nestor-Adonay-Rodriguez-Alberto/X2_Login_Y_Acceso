using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rol
    {
        // Atributos:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "Ingrese El Nombre Del Rol Que Tendra El Empleado.")]
        [StringLength(50)]
        public string Nombre { get; set; }


        // Asociada A Esta Tabla:
        public virtual List<Profesor> Lista_Profesores { get; set; }


        // Constructor:
        public Rol()
        {
            Lista_Profesores = new List<Profesor>();
        }
    }
}
