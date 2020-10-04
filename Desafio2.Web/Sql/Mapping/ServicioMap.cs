using Desafio2.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Desafio2.Web.Sql.Mapping
{
    public class ServicioMap:EntityTypeConfiguration<Servicio>
    {
        public ServicioMap() {

            HasKey(x => x.Codigo);
            this.Property(x => x.Codigo).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}