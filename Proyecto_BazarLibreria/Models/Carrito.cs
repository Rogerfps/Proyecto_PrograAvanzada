using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_BazarLibreria.Models
{
    public class Carrito
    {
        public int Id { get; set; } // PK
        public int UsuarioCodigo { get; set; } // FK
        public Usuario Usuario { get; set; }
        public decimal Total { get; set; }

        // Relación con productos
        public ICollection<CarritoProducto> CarritoProductos { get; set; }
    }
    public class CarritoProducto
    {
        public int CarritoId { get; set; } // FK
        public Carrito Carrito { get; set; }
        public int ProductoCodigo { get; set; } // FK
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}