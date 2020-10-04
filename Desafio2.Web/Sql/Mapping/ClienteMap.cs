using Desafio2.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Desafio2.Web.Sql.Mapping
{
    public class ClienteMap:EntityTypeConfiguration<Cliente>
    {
        public ClienteMap() {

            this.HasKey(x => x.Dui);
            this.Property(x => x.Dui).HasMaxLength(20);
            this.Property(x => x.Nombre).HasMaxLength(150);

            this.HasMany(x => x.Mascotas).WithRequired().HasForeignKey(x=>x.IdCliente);
        }
    }
}