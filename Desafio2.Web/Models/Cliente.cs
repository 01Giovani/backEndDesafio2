using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Desafio2.Web.Models
{
    
    public class Cliente
    {
        public Cliente()
        {
            Mascotas = new List<Mascota>();
        }
        public string Dui { get; set; }
        public string Nombre { get; set; }
        public string Celular { get; set; }
        public List<Mascota> Mascotas { get; set; }
    }
}