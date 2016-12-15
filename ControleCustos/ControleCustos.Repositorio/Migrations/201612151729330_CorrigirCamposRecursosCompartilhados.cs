namespace ControleCustos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrigirCamposRecursosCompartilhados : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RecursoCompartilhado", "EspacoEmDisco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.RecursoCompartilhado", "Processadores", c => c.Int(nullable: false));
            AlterColumn("dbo.RecursoCompartilhado", "Memoria", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RecursoCompartilhado", "Memoria", c => c.String(nullable: false));
            AlterColumn("dbo.RecursoCompartilhado", "Processadores", c => c.String(nullable: false));
            AlterColumn("dbo.RecursoCompartilhado", "EspacoEmDisco", c => c.String(nullable: false));
        }
    }
}
