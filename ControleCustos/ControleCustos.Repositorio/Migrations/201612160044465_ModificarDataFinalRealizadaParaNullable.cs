namespace ControleCustos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificarDataFinalRealizadaParaNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projeto", "DataFinalRealizada", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projeto", "DataFinalRealizada", c => c.DateTime(nullable: false));
        }
    }
}
