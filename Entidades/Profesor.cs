using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Profesor
    {
        // Atributos:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProfesor { get; set; }


        [Required(ErrorMessage = "Ingrese El Nombre.")]
        [StringLength(60)]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Ingrese El Apellido.")]
        [StringLength(60)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Ingrese El Correo Electronico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Ingrese Una Contraseña Segura.")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Debe Contener Entre 5 y 10 Caracteres.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirme La Contraseña Segura.")]
        [Compare("Password", ErrorMessage = "La Confirmacion No Coincide Intentelo De Nuevo.")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Debe Contener Entre 5 y 10 Caracteres.")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmarPassword { get; set; }


        [Required(ErrorMessage = "Ingrese La Aula Del Profesor.")]
        public int Aula { get; set; }


        public byte[]? Fotografia { get; set; }


        // Referencia Tabla Ciudad
        [ForeignKey("Objeto_Ciudad")]
        public int IdCiudadEnPersona { get; set; }
        public virtual Ciudad Objeto_Ciudad { get; set; }


        // Referencia Tabla Rol
        [ForeignKey("Objeto_Rol")]
        public int IdRolEnPersona { get; set; }
        public virtual Rol Objeto_Rol { get; set; }

        // Asociada A Esta Tabla:
        public virtual List<Materia> Lista_Materias { get; set; }


        // CONSTRUCTOR:
        public Profesor()
        {
            Lista_Materias = new List<Materia>();
        }


    }
}
