using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimerAplicacion.Models
{
    public class ViajeCLS
    {
        [Display(Name = "Id Viaje")]
        public int iidviaje { get; set; }

        [Display(Name = "Lugar origen")]
        [Required]
        public int iidlugarorigen { get; set; }

        [Display(Name = "Lugar destino")]
        [Required]
        public int iidlugardestino { get; set; }

        [Display(Name = "Precio")]
        [Required]
        public double precio { get; set; }

        [Display(Name = "Fecha de viaje")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime fechaviaje { get; set; }

        [Display(Name = "Bus")]
        [Required]
        public int iidbus { get; set; }

        [Display(Name = "Numero de asientos disponibles")]
        [Required]
        public int numeroasientosdisponibles { get; set; }

        //propiedades adicionales
        [Display(Name = "Lugar origen")]
        public string nombrelugarorigen { get; set; }

        [Display(Name = "Lugar destino")]
        public string nombrelugardestino { get; set; }

        [Display(Name = "Nombre bus")]
        public string nombrebus { get; set; }
    }
}