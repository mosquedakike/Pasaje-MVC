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
        public int iidsucursal { get; set; }

        [Display(Name = "Nombre Sucursal")]
        public string nombre { get; set; }

        [Display(Name = "Direccion")]
        public string direccion { get; set; }
        
        [Display(Name = "Telefono")]
        public string telefono { get; set; }

        [Display(Name = "Correo electronico")]
        public string email { get; set; }

        [Display(Name = "Fecha de apertura")]
        public DateTime fechaapertura { get; set; }

        [Display(Name = "Estatus")]
        public int bhabilitado { get; set; }
    }
}