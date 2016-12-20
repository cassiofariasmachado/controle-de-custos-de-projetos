namespace ControleCustos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RetirarcamposnaousadoseadicionarContaemCusto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Custo", "Conta", c => c.String());
            DropColumn("dbo.Custo", "EnergiaEletrica");
            DropColumn("dbo.Custo", "Agua");
            DropColumn("dbo.Custo", "MaterialExpediente");
            DropColumn("dbo.Custo", "MaterialEscritorio");
            DropColumn("dbo.Custo", "Condominio");
            DropColumn("dbo.Custo", "Aluguel");
            DropColumn("dbo.Custo", "Internet");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Custo", "Internet", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Custo", "Aluguel", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Custo", "Condominio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Custo", "MaterialEscritorio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Custo", "MaterialExpediente", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Custo", "Agua", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Custo", "EnergiaEletrica", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Custo", "Conta");
        }
    }
}
