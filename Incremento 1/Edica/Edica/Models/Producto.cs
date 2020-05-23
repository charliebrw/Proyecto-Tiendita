namespace Edica.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        public int IDProducto { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public string RUC { get; set; }
        public int IDCategoria { get; set; }
        public bool Estado { get; set; }
        public string Imagen { get; set; }
    
        public virtual Categoria Categoria { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
