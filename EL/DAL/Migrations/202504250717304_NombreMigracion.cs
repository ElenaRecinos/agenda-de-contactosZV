namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NombreMigracion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contactos", "GrupoId", "dbo.Grupo");
            DropIndex("dbo.Contactos", new[] { "GrupoId" });
            AlterColumn("dbo.Contactos", "GrupoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contactos", "GrupoId");
            AddForeignKey("dbo.Contactos", "GrupoId", "dbo.Grupo", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contactos", "GrupoId", "dbo.Grupo");
            DropIndex("dbo.Contactos", new[] { "GrupoId" });
            AlterColumn("dbo.Contactos", "GrupoId", c => c.Int());
            CreateIndex("dbo.Contactos", "GrupoId");
            AddForeignKey("dbo.Contactos", "GrupoId", "dbo.Grupo", "Id");
        }
    }
}
