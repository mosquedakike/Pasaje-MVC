using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimerAplicacion.Models
{
    public class SucursalCLS
    {
        [Display(Name = "Id Sucursal")]
        [Required]
        public int iidsucursal { get; set; }

        [Display(Name = "Nombre Sucursal")]
        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Display(Name = "Direccion")]
        [Required]
        [StringLength(200)]
        public string direccion { get; set; }
        
        [Display(Name = "Telefono")]
        [Required]
        [StringLength(10)]
        public string telefono { get; set; }

        [Display(Name = "Correo electronico")]
        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Display(Name = "Fecha de apertura")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime fechaapertura { get; set; }

        [Display(Name = "Estatus")]
        public int bhabilitado { get; set; }
    }
}