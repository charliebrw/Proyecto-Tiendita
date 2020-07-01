//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productos()
        {
            this.DetalleVenta = new HashSet<DetalleVenta>();
        }
    
        public int IDProducto { get; set; }
        public string proNombre { get; set; }
        public int proCantidad { get; set; }
        public decimal proPrecioVenta { get; set; }
        public int IDCategoria { get; set; }
        public string RUC { get; set; }
        public byte[] proImagen { get; set; }
        public bool proEstado { get; set; }
    
        public virtual Categorias Categorias { get; set; }
        public virtual Proveedores Proveedores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
