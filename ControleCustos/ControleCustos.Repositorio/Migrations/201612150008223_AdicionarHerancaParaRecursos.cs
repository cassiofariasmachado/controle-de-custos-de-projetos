namespace ControleCustos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarHerancaParaRecursos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecursoCompartilhado",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EnderecoIp = c.String(),
                        BaseDeDados = c.Boolean(nullable: false),
                        EspacoEmDisco = c.String(),
                        Processadores = c.String(),
                        Memoria = c.String(),
                        BackupDiario = c.Boolean(nullable: false),
                        BackupIncremental = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recurso", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.RecursoVinculadoProfissional",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Modelo = c.String(),
                        Marca = c.String(),
                        DataCompra = c.DateTime(nullable: false),
                        ValorCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TempoDeVidaUtil = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recurso", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Servico",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Descricao = c.String(),
                        TipoServico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recurso", t => t.Id)
                .Index(t => t.Id);
            
            DropColumn("dbo.Recurso", "EnderecoIp");
            DropColumn("dbo.Recurso", "BaseDeDados");
            DropColumn("dbo.Recurso", "EspacoEmDisco");
            DropColumn("dbo.Recurso", "Processadores");
            DropColumn("dbo.Recurso", "Memoria");
            DropColumn("dbo.Recurso", "BackupDiario");
            DropColumn("dbo.Recurso", "BackupIncremental");
            DropColumn("dbo.Recurso", "Modelo");
            DropColumn("dbo.Recurso", "Marca");
            DropColumn("dbo.Recurso", "DataCompra");
            DropColumn("dbo.Recurso", "ValorCompra");
            DropColumn("dbo.Recurso", "TempoDeVidaUtil");
            DropColumn("dbo.Recurso", "Descricao");
            DropColumn("dbo.Recurso", "TipoServico");
            DropColumn("dbo.Recurso", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recurso", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Recurso", "TipoServico", c => c.Int());
            AddColumn("dbo.Recurso", "Descricao", c => c.String());
            AddColumn("dbo.Recurso", "TempoDeVidaUtil", c => c.Int());
            AddColumn("dbo.Recurso", "ValorCompra", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Recurso", "DataCompra", c => c.DateTime());
            AddColumn("dbo.Recurso", "Marca", c => c.String());
            AddColumn("dbo.Recurso", "Modelo", c => c.String());
            AddColumn("dbo.Recurso", "BackupIncremental", c => c.Boolean());
            AddColumn("dbo.Recurso", "BackupDiario", c => c.Boolean());
            AddColumn("dbo.Recurso", "Memoria", c => c.String());
            AddColumn("dbo.Recurso", "Processadores", c => c.String());
            AddColumn("dbo.Recurso", "EspacoEmDisco", c => c.String());
            AddColumn("dbo.Recurso", "BaseDeDados", c => c.Boolean());
            AddColumn("dbo.Recurso", "EnderecoIp", c => c.String());
            DropForeignKey("dbo.Servico", "Id", "dbo.Recurso");
            DropForeignKey("dbo.RecursoVinculadoProfissional", "Id", "dbo.Recurso");
            DropForeignKey("dbo.RecursoCompartilhado", "Id", "dbo.Recurso");
            DropIndex("dbo.Servico", new[] { "Id" });
            DropIndex("dbo.RecursoVinculadoProfissional", new[] { "Id" });
            DropIndex("dbo.RecursoCompartilhado", new[] { "Id" });
            DropTable("dbo.Servico");
            DropTable("dbo.RecursoVinculadoProfissional");
            DropTable("dbo.RecursoCompartilhado");
        }
    }
}
