namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contactos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Email = c.String(),
                        GrupoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grupo", t => t.GrupoId, cascadeDelete: true)
                .Index(t => t.GrupoId);
            
            CreateTable(
                "dbo.Grupo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Telefono",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        Tipo = c.String(),
                        ContactoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contactos", t => t.ContactoId, cascadeDelete: true)
                .Index(t => t.ContactoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefono", "ContactoId", "dbo.Contactos");
            DropForeignKey("dbo.Contactos", "GrupoId", "dbo.Grupo");
            DropIndex("dbo.Telefono", new[] { "ContactoId" });
            DropIndex("dbo.Contactos", new[] { "GrupoId" });
            DropTable("dbo.Telefono");
            DropTable("dbo.Grupo");
            DropTable("dbo.Contactos");
        }
    }
}
