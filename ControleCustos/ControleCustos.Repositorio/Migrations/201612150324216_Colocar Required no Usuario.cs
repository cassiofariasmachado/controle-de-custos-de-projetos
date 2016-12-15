namespace ControleCustos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColocarRequirednoUsuario : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuario", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "Senha", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuario", "Senha", c => c.String());
            AlterColumn("dbo.Usuario", "Email", c => c.String());
            AlterColumn("dbo.Usuario", "Nome", c => c.String());
        }
    }
}
