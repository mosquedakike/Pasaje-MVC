using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimerAplicacion.Models
{
    public class ClienteCLS
    {
        [Display(Name = "Id")]
        public int iidclinete { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(100,ErrorMessage ="La longitud maxima es de 100")]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [StringLength(150,ErrorMessage ="La longitud maxima es de 150")]
        [Required]
        public string appaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [StringLength(150, ErrorMessage ="La longitud maxima es de 150")]
        [Required]
        public string apmaterno { get; set; }

        [Display(Name = "Correo")]
        [EmailAddress(ErrorMessage ="Ingrese un correo valido")]
        [Required]
        public string email { get; set; }

        [Display(Name = "Direccion")]
        [DataType(DataType.MultilineText)]
        [Required]
        [StringLength(200,ErrorMessage ="La longitud maxima es 200")]
        public string direccion { get; set; }

        [Display(Name = "Sexo")]
        [Required]
        public int iidsexo { get; set; }

        [Display(Name = "Telefono fijo")]
        [Required]
        [StringLength(10,ErrorMessage ="La logitud maxima es 10")]
        public string telefonofijo { get; set; }

        [Display(Name ="Telefono celular")]
        [Required]
        [StringLength(10,ErrorMessage ="La longitud maxima es 10")]
        public string telefonocelular { get; set; }

        [Display(Name ="Estatus")]
        [Required]
        public int bhabilitado { get; set; }

    }
}