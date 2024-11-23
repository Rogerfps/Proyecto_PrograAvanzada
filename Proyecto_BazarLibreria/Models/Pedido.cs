using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_BazarLibreria.Models
{
    public class Pedido
    {
        public int Id { get; set; } // PK
        public int HistorialId { get; set; } // FK
        public Historial Historial { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
    }
}