using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Desafio2.Web.Models
{
    
    public class Mascota
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string IdCliente { get; set; }
        //public Cliente Cliente { get; set; }

    }
}