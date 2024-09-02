using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciudad
    {
        // Atributos:

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCiudad { get; set; }


        [Required(ErrorMessage = "Ingrese El Nombre De La Ciudad")]
        [StringLength(50)]
        public string Nombre { get; set; }



        // Asociada A Esta Tabla:
        public virtual List<Profesor> Lista_Profesores { get; set; }


        // Constructor:
        public Ciudad()
        {
            Lista_Profesores = new List<Profesor>();
        }
    }
}
