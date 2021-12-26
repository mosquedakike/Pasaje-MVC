using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimerAplicacion.Models
{
    public class EmpleadoCLS
    {
        [Display(Name = "Id Empleado")]
        public int iidEmpleado { get; set; }

        [Display(Name ="Nombre")]
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        [Required]
        public string nombre { get; set; }

        [Display(Name="Apellido Paterno")]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        [Required]
        public string apPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        [Required]
        public string apMaterno { get; set; }

        [Display(Name = "Fecha de Contrato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime fechaContrato { get; set; }

        [Display(Name = "Tipo Usuario")]
        [Required]
        public int iidTipoUsuario { get; set; }

        [Display(Name = "Contrato")]
        [Required]
        public int iidTipoContrato { get; set; }

        [Display(Name = "Sexo")]
        [Required]
        public int iidsexo { get; set; }
        
        [Required]
        public int bhabilitado { get; set; }


        //propiedades adicionales
        [Display(Name = "Contrato")]
        public string nombreTipoContrato { get; set; }

        [Display(Name = "Usuario")]
        public string nombreTipoUsuario { get; set; }

    }
}