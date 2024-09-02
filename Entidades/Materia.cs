using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Materia
    {
        // Atributos:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMateria { get; set; }



        [Required(ErrorMessage = "Ingrese El Nombre De La Materia.")]
        [StringLength(100, ErrorMessage = "El Nombre debe Ser Menor a 100 Caracteres")]
        public string Nombre { get; set; }



        [Required(ErrorMessage = "Ingrese El Horario De La Materia.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Ejemplo De Horario 00:00 am")]
        public string Horario { get; set; }


        // Asociada A Esta Tabla:
        public virtual List<Estudiante> Lista_Estudiante { get; set; }


        // Referencia Tabla Profesor
        [ForeignKey("Objeto_Profesor")]
        public int IdProfesorEnMateria { get; set; }
        public virtual Profesor Objeto_Profesor { get; set; }



        // Constructor:
        public Materia()
        {
            Lista_Estudiante = new List<Estudiante>();
        }
    }
}
