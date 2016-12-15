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
                        Nome = c.String(),
                        TipoRecurso = c.Int(nullable: false),
                        ValorMensal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Situacao = c.Int(nullable: false),
                        EnderecoIp = c.String(),
                        BaseDeDados = c.Boolean(),
                        EspacoEmDisco = c.String(),
                        Processadores = c.String(),
                        Memoria = c.String(),
                        BackupDiario = c.Boolean(),
                        BackupIncremental = c.Boolean(),
                        Modelo = c.String(),
                        Marca = c.String(),
                        DataCompra = c.DateTime(),
                        ValorCompra = c.Decimal(precision: 18, scale: 2),
                        TempoDeVidaUtil = c.Int(),
                        Descricao = c.String(),
                        TipoServico = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
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
