using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estudiante
    {
        // Atributos:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstudiante { get; set; }



        [Required(ErrorMessage = "Ingrese Los Nombre.")]
        public string Nombre { get; set; }



        [Required(ErrorMessage = "Ingrese Los Apellidos.")]
        public string Apellidos { get; set; }



        [Required(ErrorMessage = "Ingrese El Correo Electronico.")]
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



        [Required(ErrorMessage = "Ingrese El Numero De Telefono.")]
        public string Telefono { get; set; }


        public byte[]? Fotografia { get; set; }


        // Referencia Tabla Materia:
        [ForeignKey("Objeto_Materia")]
        public int IdMateriaEnEstudiante { get; set; }
        public virtual Materia Objeto_Materia { get; set; }
    }
}
