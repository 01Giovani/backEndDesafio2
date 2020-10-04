using Desafio2.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Desafio2.Web.Sql.Mapping
{
    public class ConsultaMap:EntityTypeConfiguration<Consulta>
    {
        public ConsultaMap() {

            this.HasKey(x => x.Codigo);
            this.Property(x => x.IdCliente).HasMaxLength(20);
            this.Property(x => x.Codigo).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.HasRequired(x => x.Servicio).WithMany().HasForeignKey(x => x.IdServicio);
            this.HasRequired(x => x.Mascota).WithMany().HasForeignKey(x => x.IdMascota);
            this.HasRequired(x => x.Cliente).WithMany().HasForeignKey(x => x.IdCliente);
        }
    }
}