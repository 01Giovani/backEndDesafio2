using Desafio2.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Desafio2.Web.Sql.Mapping
{
    public class MascotaMap:EntityTypeConfiguration<Mascota>
    {
        public MascotaMap() {

            this.HasKey(x => x.Codigo);
            this.Property(x => x.Codigo).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(x => x.Nombre).HasMaxLength(150);

            //this.HasRequired(x => x.Cliente).WithMany(x => x.Mascotas).HasForeignKey(x => x.IdCliente);
        }
    }
}