namespace Proyecto_BazarLibreria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datos_Bazar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarritoProductoes",
                c => new
                    {
                        CarritoId = c.Int(nullable: false, identity: true),
                        ProductoCodigo = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Carrito_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CarritoId)
                .ForeignKey("dbo.Carritoes", t => t.Carrito_Id)
                .ForeignKey("dbo.Productoes", t => t.ProductoCodigo, cascadeDelete: true)
                .Index(t => t.ProductoCodigo)
                .Index(t => t.Carrito_Id);
            
            CreateTable(
                "dbo.Carritoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioCodigo = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioCodigo, cascadeDelete: true)
                .Index(t => t.UsuarioCodigo);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Contraseña = c.String(),
                        UltimaConexion = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Historials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioCodigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioCodigo, cascadeDelete: true)
                .Index(t => t.UsuarioCodigo);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HistorialId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Historials", t => t.HistorialId, cascadeDelete: true)
                .Index(t => t.HistorialId);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Disponibilidad = c.Boolean(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Imagens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        ProductoCodigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productoes", t => t.ProductoCodigo, cascadeDelete: true)
                .Index(t => t.ProductoCodigo);
            
            CreateTable(
                "dbo.Reseña",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductoCodigo = c.Int(nullable: false),
                        Comentario = c.String(),
                        Calificacion = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productoes", t => t.ProductoCodigo, cascadeDelete: true)
                .Index(t => t.ProductoCodigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reseña", "ProductoCodigo", "dbo.Productoes");
            DropForeignKey("dbo.Imagens", "ProductoCodigo", "dbo.Productoes");
            DropForeignKey("dbo.CarritoProductoes", "ProductoCodigo", "dbo.Productoes");
            DropForeignKey("dbo.Historials", "UsuarioCodigo", "dbo.Usuarios");
            DropForeignKey("dbo.Pedidoes", "HistorialId", "dbo.Historials");
            DropForeignKey("dbo.Carritoes", "UsuarioCodigo", "dbo.Usuarios");
            DropForeignKey("dbo.CarritoProductoes", "Carrito_Id", "dbo.Carritoes");
            DropIndex("dbo.Reseña", new[] { "ProductoCodigo" });
            DropIndex("dbo.Imagens", new[] { "ProductoCodigo" });
            DropIndex("dbo.Pedidoes", new[] { "HistorialId" });
            DropIndex("dbo.Historials", new[] { "UsuarioCodigo" });
            DropIndex("dbo.Carritoes", new[] { "UsuarioCodigo" });
            DropIndex("dbo.CarritoProductoes", new[] { "Carrito_Id" });
            DropIndex("dbo.CarritoProductoes", new[] { "ProductoCodigo" });
            DropTable("dbo.Reseña");
            DropTable("dbo.Imagens");
            DropTable("dbo.Productoes");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.Historials");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Carritoes");
            DropTable("dbo.CarritoProductoes");
        }
    }
}
