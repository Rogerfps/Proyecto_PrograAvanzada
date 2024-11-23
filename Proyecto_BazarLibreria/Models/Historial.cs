using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_BazarLibreria.Models
{
    public class Historial
    {
        public int Id { get; set; } // PK
        public int UsuarioCodigo { get; set; } // FK
        public Usuario Usuario { get; set; }

        // Relación con pedidos
        public ICollection<Pedido> Pedidos { get; set; }
    }
}