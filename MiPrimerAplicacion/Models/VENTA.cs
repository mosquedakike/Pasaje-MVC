//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiPrimerAplicacion.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VENTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VENTA()
        {
            this.DETALLEVENTA = new HashSet<DETALLEVENTA>();
        }
    
        public int IIDVENTA { get; set; }
        public Nullable<int> IIDCLIENTE { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
        public Nullable<System.DateTime> FECHAVENTA { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLEVENTA> DETALLEVENTA { get; set; }
    }
}
