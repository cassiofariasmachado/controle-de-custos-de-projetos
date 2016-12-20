namespace ControleCustos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        UnidadeTecnica_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UnidadeTecnica", t => t.UnidadeTecnica_Id)
                .Index(t => t.UnidadeTecnica_Id);
            
            CreateTable(
                "dbo.UnidadeTecnica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Sigla = c.String(nullable: false),
                        Local = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ControleRecurso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        Projeto_Id = c.Int(nullable: false),
                        Recurso_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projeto", t => t.Projeto_Id)
                .ForeignKey("dbo.Recurso", t => t.Recurso_Id)
                .Index(t => t.Projeto_Id)
                .Index(t => t.Recurso_Id);
            
            CreateTable(
                "dbo.Projeto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cliente = c.String(nullable: false),
                        Tecnologia = c.String(nullable: false),
                        DataInicio = c.DateTime(nullable: false),
                        DataFinalPrevista = c.DateTime(nullable: false),
                        DataFinalRealizada = c.DateTime(),
                        FaturamentoPrevisto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FaturamentoRealizado = c.Decimal(precision: 18, scale: 2),
                        NumeroDeProfissionais = c.Int(nullable: false),
                        Situacao = c.Int(nullable: false),
                        Gerente_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Gerente_Id)
                .Index(t => t.Gerente_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        Permissao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recurso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        ValorMensal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Situacao = c.Int(nullable: false),
                        Interno = c.Boolean(nullable: false),
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
                        UnidadeTecnica_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UnidadeTecnica", t => t.UnidadeTecnica_Id)
                .Index(t => t.UnidadeTecnica_Id);
            
            CreateTable(
                "dbo.Compartilhado",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EnderecoIp = c.String(nullable: false),
                        BaseDeDados = c.Boolean(nullable: false),
                        EspacoEmDisco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Processadores = c.Int(nullable: false),
                        Memoria = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BackupDiario = c.Boolean(nullable: false),
                        BackupIncremental = c.Boolean(nullable: false),
                        TipoRecurso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recurso", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Patrimonio",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Modelo = c.String(nullable: false),
                        Marca = c.String(nullable: false),
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
                        Descricao = c.String(nullable: false),
                        TipoServico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recurso", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servico", "Id", "dbo.Recurso");
            DropForeignKey("dbo.Patrimonio", "Id", "dbo.Recurso");
            DropForeignKey("dbo.Compartilhado", "Id", "dbo.Recurso");
            DropForeignKey("dbo.Custo", "UnidadeTecnica_Id", "dbo.UnidadeTecnica");
            DropForeignKey("dbo.ControleRecurso", "Recurso_Id", "dbo.Recurso");
            DropForeignKey("dbo.ControleRecurso", "Projeto_Id", "dbo.Projeto");
            DropForeignKey("dbo.Projeto", "Gerente_Id", "dbo.Usuario");
            DropForeignKey("dbo.Colaboradores", "UnidadeTecnica_Id", "dbo.UnidadeTecnica");
            DropIndex("dbo.Servico", new[] { "Id" });
            DropIndex("dbo.Patrimonio", new[] { "Id" });
            DropIndex("dbo.Compartilhado", new[] { "Id" });
            DropIndex("dbo.Custo", new[] { "UnidadeTecnica_Id" });
            DropIndex("dbo.Projeto", new[] { "Gerente_Id" });
            DropIndex("dbo.ControleRecurso", new[] { "Recurso_Id" });
            DropIndex("dbo.ControleRecurso", new[] { "Projeto_Id" });
            DropIndex("dbo.Colaboradores", new[] { "UnidadeTecnica_Id" });
            DropTable("dbo.Servico");
            DropTable("dbo.Patrimonio");
            DropTable("dbo.Compartilhado");
            DropTable("dbo.Custo");
            DropTable("dbo.Recurso");
            DropTable("dbo.Usuario");
            DropTable("dbo.Projeto");
            DropTable("dbo.ControleRecurso");
            DropTable("dbo.UnidadeTecnica");
            DropTable("dbo.Colaboradores");
        }
    }
}
