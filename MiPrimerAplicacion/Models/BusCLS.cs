using System;
using System.ComponentModel.DataAnnotations;

namespace MiPrimerAplicacion.Models
{
    public class BusCLS
    {
        [Display(Name = "ID")]
        public int iidbus { get; set; }
        
        [Display(Name = "Nombre Sucurusal")]
        [Required]
        public int idsucursal { get; set; }
        
        [Display(Name = "Tipo Bus")]
        [Required]
        public int iidtipobus { get; set; }

        [Display(Name = "Fecha de compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime fechacompra { get; set; }
        
        [Display(Name = "Nombre modelo")]
        [Required]
        public int iidmodelo { get; set; }
        
        [Display(Name = "Numero de filas")]
        [Required]
        public int numerofilas { get; set; }
        
        [Display(Name = "Numero de columnas")]
        [Required]
        public int numerocolumnas { get; set; }

        public int bhabilitado { get; set; }

        [Display(Name = "Descripcion")]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        [Required]
        public string descripcion { get; set; }

        [Display(Name = "Observaciones")]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        public string observaciones { get; set; }

        [Display(Name = "Nombre marca")]
        [Required]
        public int iidmarca { get; set; }

        //propiedades adiconales
        [Display(Name = "Nombre sucursal")]
        public string nombresucursal { get; set; }

        [Display(Name = "Tipo bus")]
        public string nombretipobus { get; set; }

        [Display(Name = "Nombre modelo")]
        public string nombremodelo { get; set; }
    }
}