namespace ControleCustos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recurso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        TipoRecurso = c.Int(nullable: false),
                        ValorMensal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Situacao = c.Int(nullable: false),
                        EnderecoIp = c.String(nullable: false),
                        BaseDeDados = c.Boolean(nullable: false),
                        EspacoEmDisco = c.String(nullable: false),
                        Processadores = c.String(nullable: false),
                        Memoria = c.String(nullable: false),
                        BackupDiario = c.Boolean(nullable: false),
                        BackupIncremental = c.Boolean(nullable: false),
                        Modelo = c.String(nullable: false),
                        Marca = c.String(nullable: false),
                        DataCompra = c.DateTime(nullable: false),
                        ValorCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TempoDeVidaUtil = c.Int(nullable: false),
                        Descricao = c.String(nullable: false),
                        TipoServico = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
            DropTable("dbo.Recurso");
        }
    }
}
