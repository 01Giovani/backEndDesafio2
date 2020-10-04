namespace Desafio2.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Dui = c.String(nullable: false, maxLength: 20),
                        Nombre = c.String(maxLength: 150),
                        Celular = c.String(),
                    })
                .PrimaryKey(t => t.Dui);
            
            CreateTable(
                "dbo.Mascotas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 150),
                        IdCliente = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Clientes", t => t.IdCliente, cascadeDelete: true)
                .Index(t => t.IdCliente);
            
            CreateTable(
                "dbo.Consultas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdServicio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Servicios", t => t.IdServicio, cascadeDelete: true)
                .Index(t => t.IdServicio);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultas", "IdServicio", "dbo.Servicios");
            DropForeignKey("dbo.Mascotas", "IdCliente", "dbo.Clientes");
            DropIndex("dbo.Consultas", new[] { "IdServicio" });
            DropIndex("dbo.Mascotas", new[] { "IdCliente" });
            DropTable("dbo.Servicios");
            DropTable("dbo.Consultas");
            DropTable("dbo.Mascotas");
            DropTable("dbo.Clientes");
        }
    }
}
