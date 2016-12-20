namespace ControleCustos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrigirNomeDeTabelasEAdicionarPropriedadeInterno : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RecursoCompartilhado", newName: "Compartilhado");
            RenameTable(name: "dbo.RecursoVinculadoProfissional", newName: "Patrimonio");
            AddColumn("dbo.Recurso", "Interno", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recurso", "Interno");
            RenameTable(name: "dbo.Patrimonio", newName: "RecursoVinculadoProfissional");
            RenameTable(name: "dbo.Compartilhado", newName: "RecursoCompartilhado");
        }
    }
}
