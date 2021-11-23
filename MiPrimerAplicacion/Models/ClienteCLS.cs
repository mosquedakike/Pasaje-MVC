using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimerAplicacion.Models
{
    public class ClienteCLS
    {
        [Display(Name="Id")]
        public int iidclinete { get; set; }
        [Display(Name="Nombre")]
        public string nombre { get; set; }
        [Display(Name="Apellido Paterno")]
        public string appaterno { get; set; }
        [Display(Name ="Apellido Materno")]
        public string apmaterno { get; set; }
        [Display(Name ="Correo")]
        public string email { get; set; }
        [Display(Name="Direccion")]
        public string direccion { get; set; }
        [Display(Name ="Sexo")]
        public int iidsexo { get; set; }
        [Display(Name = "Telefono fijo")]
        public string telefonofijo { get; set; }
        [Display(Name ="Telefono celular")]
        public string telefonocelular { get; set; }
        [Display(Name ="Estatus")]
        public int bhabilitado { get; set; }

    }
}