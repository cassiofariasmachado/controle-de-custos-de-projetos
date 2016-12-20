namespace ControleCustos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarastabelasUnidadeTecnicaCustoeColaboradores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colaboradores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuantidadeDeColaboradores = c.Int(nullable: false),
                        Periodo = c.DateTime(nullable: false),
                        UnidadeTecnica_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UnidadeTecnica", t => t.UnidadeTecnica_Id)
                .Index(t => t.UnidadeTecnica_Id);
            
            CreateTable(
                "dbo.UnidadeTecnica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sigla = c.String(),
                        Local = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Custo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnergiaEletrica = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Agua = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaterialExpediente = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaterialEscritorio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Condominio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Aluguel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Internet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Periodo = c.DateTime(nullable: false),
                        UnidadeTecnica_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UnidadeTecnica", t => t.UnidadeTecnica_Id)
                .Index(t => t.UnidadeTecnica_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Custo", "UnidadeTecnica_Id", "dbo.UnidadeTecnica");
            DropForeignKey("dbo.Colaboradores", "UnidadeTecnica_Id", "dbo.UnidadeTecnica");
            DropIndex("dbo.Custo", new[] { "UnidadeTecnica_Id" });
            DropIndex("dbo.Colaboradores", new[] { "UnidadeTecnica_Id" });
            DropTable("dbo.Custo");
            DropTable("dbo.UnidadeTecnica");
            DropTable("dbo.Colaboradores");
        }
    }
}
