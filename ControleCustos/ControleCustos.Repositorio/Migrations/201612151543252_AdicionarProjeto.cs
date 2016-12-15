namespace ControleCustos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarProjeto : DbMigration
    {
        public override void Up()
        {
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
                        DataFinalRealizada = c.DateTime(nullable: true),
                        FaturamentoPrevisto = c.Double(nullable: false),
                        FaturamentoRealizado = c.Double(nullable: true),
                        NumeroDeProfissionais = c.Int(nullable: false),
                        Situacao = c.Int(nullable: false),
                        Gerente_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Gerente_Id, cascadeDelete: true)
                .Index(t => t.Gerente_Id);
            
            CreateTable(
                "dbo.RecursoProjeto",
                c => new
                    {
                        Recurso_Id = c.Int(nullable: false),
                        Projeto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recurso_Id, t.Projeto_Id })
                .ForeignKey("dbo.Recurso", t => t.Recurso_Id, cascadeDelete: true)
                .ForeignKey("dbo.Projeto", t => t.Projeto_Id, cascadeDelete: true)
                .Index(t => t.Recurso_Id)
                .Index(t => t.Projeto_Id);
            
            AlterColumn("dbo.Recurso", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.RecursoCompartilhado", "EnderecoIp", c => c.String(nullable: false));
            AlterColumn("dbo.RecursoCompartilhado", "EspacoEmDisco", c => c.String(nullable: false));
            AlterColumn("dbo.RecursoCompartilhado", "Processadores", c => c.String(nullable: false));
            AlterColumn("dbo.RecursoCompartilhado", "Memoria", c => c.String(nullable: false));
            AlterColumn("dbo.RecursoVinculadoProfissional", "Modelo", c => c.String(nullable: false));
            AlterColumn("dbo.RecursoVinculadoProfissional", "Marca", c => c.String(nullable: false));
            AlterColumn("dbo.Servico", "Descricao", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecursoProjeto", "Projeto_Id", "dbo.Projeto");
            DropForeignKey("dbo.RecursoProjeto", "Recurso_Id", "dbo.Recurso");
            DropForeignKey("dbo.Projeto", "Gerente_Id", "dbo.Usuario");
            DropIndex("dbo.RecursoProjeto", new[] { "Projeto_Id" });
            DropIndex("dbo.RecursoProjeto", new[] { "Recurso_Id" });
            DropIndex("dbo.Projeto", new[] { "Gerente_Id" });
            AlterColumn("dbo.Servico", "Descricao", c => c.String());
            AlterColumn("dbo.RecursoVinculadoProfissional", "Marca", c => c.String());
            AlterColumn("dbo.RecursoVinculadoProfissional", "Modelo", c => c.String());
            AlterColumn("dbo.RecursoCompartilhado", "Memoria", c => c.String());
            AlterColumn("dbo.RecursoCompartilhado", "Processadores", c => c.String());
            AlterColumn("dbo.RecursoCompartilhado", "EspacoEmDisco", c => c.String());
            AlterColumn("dbo.RecursoCompartilhado", "EnderecoIp", c => c.String());
            AlterColumn("dbo.Recurso", "Nome", c => c.String());
            DropTable("dbo.RecursoProjeto");
            DropTable("dbo.Projeto");
        }
    }
}
