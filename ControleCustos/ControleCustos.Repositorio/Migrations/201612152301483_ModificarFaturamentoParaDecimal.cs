namespace ControleCustos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificarFaturamentoParaDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projeto", "FaturamentoPrevisto", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Projeto", "FaturamentoRealizado", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projeto", "FaturamentoRealizado", c => c.Double(nullable: false));
            AlterColumn("dbo.Projeto", "FaturamentoPrevisto", c => c.Double(nullable: false));
        }
    }
}
