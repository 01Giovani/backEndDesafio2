using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desafio2.Web.Models
{
    public class Consulta
    {
        public int Codigo { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public string  IdCliente { get; set; }
        public int IdMascota { get; set; }
        public int IdServicio { get; set; }
        public Servicio Servicio { get; set; }
        public Cliente Cliente { get; set; }
        public Mascota Mascota { get; set; }
    }
}