using Desafio2.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Desafio2.Web.Sql
{
    public class VeterinariaContext : DbContext
    {
        public VeterinariaContext() : base("Name=VeterinariaContext")
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Consulta> Consulta {get;set;}
        public DbSet<Servicio> Servicio { get; set; }


        protected override void OnModelCreating(DbModelBuilder md)
        {
            base.OnModelCreating(md);

            md.Configurations.Add(new Mapping.ClienteMap());
            md.Configurations.Add(new Mapping.ConsultaMap());
            md.Configurations.Add(new Mapping.MascotaMap());
            md.Configurations.Add(new Mapping.ServicioMap());
        } 
    
        
    }
}