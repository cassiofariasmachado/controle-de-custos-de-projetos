namespace ControleCustos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarValoremCusto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Custo", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Custo", "Valor");
        }
    }
}
