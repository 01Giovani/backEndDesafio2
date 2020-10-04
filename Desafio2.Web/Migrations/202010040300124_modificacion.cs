namespace Desafio2.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consultas", "IdCliente", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Consultas", "IdMascota", c => c.Int(nullable: false));
            CreateIndex("dbo.Consultas", "IdCliente");
            CreateIndex("dbo.Consultas", "IdMascota");
            AddForeignKey("dbo.Consultas", "IdCliente", "dbo.Clientes", "Dui", cascadeDelete: false);
            AddForeignKey("dbo.Consultas", "IdMascota", "dbo.Mascotas", "Codigo", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultas", "IdMascota", "dbo.Mascotas");
            DropForeignKey("dbo.Consultas", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.Consultas", new[] { "IdMascota" });
            DropIndex("dbo.Consultas", new[] { "IdCliente" });
            DropColumn("dbo.Consultas", "IdMascota");
            DropColumn("dbo.Consultas", "IdCliente");
        }
    }
}
