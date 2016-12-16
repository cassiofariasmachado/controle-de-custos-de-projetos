namespace ControleCustos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarControleRecurso : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecursoProjeto", "Recurso_Id", "dbo.Recurso");
            DropForeignKey("dbo.RecursoProjeto", "Projeto_Id", "dbo.Projeto");
            DropIndex("dbo.RecursoProjeto", new[] { "Recurso_Id" });
            DropIndex("dbo.RecursoProjeto", new[] { "Projeto_Id" });
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
                .ForeignKey("dbo.Projeto", t => t.Projeto_Id, cascadeDelete: true)
                .ForeignKey("dbo.Recurso", t => t.Recurso_Id, cascadeDelete: true)
                .Index(t => t.Projeto_Id)
                .Index(t => t.Recurso_Id);
            
            DropTable("dbo.RecursoProjeto");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RecursoProjeto",
                c => new
                    {
                        Recurso_Id = c.Int(nullable: false),
                        Projeto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recurso_Id, t.Projeto_Id });
            
            DropForeignKey("dbo.ControleRecurso", "Recurso_Id", "dbo.Recurso");
            DropForeignKey("dbo.ControleRecurso", "Projeto_Id", "dbo.Projeto");
            DropIndex("dbo.ControleRecurso", new[] { "Recurso_Id" });
            DropIndex("dbo.ControleRecurso", new[] { "Projeto_Id" });
            DropTable("dbo.ControleRecurso");
            CreateIndex("dbo.RecursoProjeto", "Projeto_Id");
            CreateIndex("dbo.RecursoProjeto", "Recurso_Id");
            AddForeignKey("dbo.RecursoProjeto", "Projeto_Id", "dbo.Projeto", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RecursoProjeto", "Recurso_Id", "dbo.Recurso", "Id", cascadeDelete: true);
        }
    }
}
