namespace ControleCustos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefatorarEntidades : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ControleRecurso", "Projeto_Id", "dbo.Projeto");
            DropForeignKey("dbo.ControleRecurso", "Recurso_Id", "dbo.Recurso");
            DropForeignKey("dbo.Projeto", "Gerente_Id", "dbo.Usuario");
            DropIndex("dbo.ControleRecurso", new[] { "Projeto_Id" });
            DropIndex("dbo.ControleRecurso", new[] { "Recurso_Id" });
            DropIndex("dbo.Projeto", new[] { "Gerente_Id" });
            AlterColumn("dbo.ControleRecurso", "Projeto_Id", c => c.Int());
            AlterColumn("dbo.ControleRecurso", "Recurso_Id", c => c.Int());
            AlterColumn("dbo.Projeto", "Nome", c => c.String());
            AlterColumn("dbo.Projeto", "Cliente", c => c.String());
            AlterColumn("dbo.Projeto", "Tecnologia", c => c.String());
            AlterColumn("dbo.Projeto", "FaturamentoRealizado", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Projeto", "Gerente_Id", c => c.Long());
            AlterColumn("dbo.Usuario", "Nome", c => c.String());
            AlterColumn("dbo.Usuario", "Email", c => c.String());
            AlterColumn("dbo.Usuario", "Senha", c => c.String());
            AlterColumn("dbo.Recurso", "Nome", c => c.String());
            AlterColumn("dbo.RecursoCompartilhado", "EnderecoIp", c => c.String());
            AlterColumn("dbo.RecursoVinculadoProfissional", "Modelo", c => c.String());
            AlterColumn("dbo.RecursoVinculadoProfissional", "Marca", c => c.String());
            AlterColumn("dbo.Servico", "Descricao", c => c.String());
            CreateIndex("dbo.ControleRecurso", "Projeto_Id");
            CreateIndex("dbo.ControleRecurso", "Recurso_Id");
            CreateIndex("dbo.Projeto", "Gerente_Id");
            AddForeignKey("dbo.ControleRecurso", "Projeto_Id", "dbo.Projeto", "Id");
            AddForeignKey("dbo.ControleRecurso", "Recurso_Id", "dbo.Recurso", "Id");
            AddForeignKey("dbo.Projeto", "Gerente_Id", "dbo.Usuario", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projeto", "Gerente_Id", "dbo.Usuario");
            DropForeignKey("dbo.ControleRecurso", "Recurso_Id", "dbo.Recurso");
            DropForeignKey("dbo.ControleRecurso", "Projeto_Id", "dbo.Projeto");
            DropIndex("dbo.Projeto", new[] { "Gerente_Id" });
            DropIndex("dbo.ControleRecurso", new[] { "Recurso_Id" });
            DropIndex("dbo.ControleRecurso", new[] { "Projeto_Id" });
            AlterColumn("dbo.Servico", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.RecursoVinculadoProfissional", "Marca", c => c.String(nullable: false));
            AlterColumn("dbo.RecursoVinculadoProfissional", "Modelo", c => c.String(nullable: false));
            AlterColumn("dbo.RecursoCompartilhado", "EnderecoIp", c => c.String(nullable: false));
            AlterColumn("dbo.Recurso", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Senha", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Projeto", "Gerente_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Projeto", "FaturamentoRealizado", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Projeto", "Tecnologia", c => c.String(nullable: false));
            AlterColumn("dbo.Projeto", "Cliente", c => c.String(nullable: false));
            AlterColumn("dbo.Projeto", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.ControleRecurso", "Recurso_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ControleRecurso", "Projeto_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Projeto", "Gerente_Id");
            CreateIndex("dbo.ControleRecurso", "Recurso_Id");
            CreateIndex("dbo.ControleRecurso", "Projeto_Id");
            AddForeignKey("dbo.Projeto", "Gerente_Id", "dbo.Usuario", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ControleRecurso", "Recurso_Id", "dbo.Recurso", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ControleRecurso", "Projeto_Id", "dbo.Projeto", "Id", cascadeDelete: true);
        }
    }
}
