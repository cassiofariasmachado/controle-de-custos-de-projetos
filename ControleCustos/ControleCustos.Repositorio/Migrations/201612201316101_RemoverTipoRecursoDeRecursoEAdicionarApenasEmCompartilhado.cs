namespace ControleCustos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoverTipoRecursoDeRecursoEAdicionarApenasEmCompartilhado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Compartilhado", "TipoRecurso", c => c.Int(nullable: false));
            DropColumn("dbo.Recurso", "TipoRecurso");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recurso", "TipoRecurso", c => c.Int(nullable: false));
            DropColumn("dbo.Compartilhado", "TipoRecurso");
        }
    }
}
