namespace ControleCustos.Repositorio.Migrations
{
    using Dominio;
    using Dominio.Enum;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ControleCustos.Repositorio.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ControleCustos.Repositorio.DatabaseContext context)
        {
            context.Usuario.AddOrUpdate(u => u.Id,
                new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com", "446ffac81f08f558556ea6d61a49dc17", Permissao.Administrador),
                new Usuario(2, "Mateus Ramos", "mateus@cwi.com", "4d821c9cc14e6ed34342b96bc4dab7d2", Permissao.Administrador),
                new Usuario(3, "Gabriel Rosa", "gabriel@cwi.com", "fa7446a73be910732a1d368d377f8356", Permissao.Administrador),
                new Usuario(4, "Andre Nunes", "nunes@cwi.com", "f89f55479e2e21d547e1890f76166ead", Permissao.Gerente)
                );
            context.SaveChanges();

            context.Projeto.AddOrUpdate(p => p.Id,
                new Projeto(1, "Máquinas da felicidade", context.Usuario.Find(2), "Coca-cola", "C#", new DateTime(2016, 9, 20), new DateTime(2016, 12, 20), 100000.00M, 10, SituacaoProjeto.EmAndamento),
                new Projeto(2, "Projeto site do Sicredi", context.Usuario.Find(1), "Sicredi", "Java", new DateTime(2016, 3, 5), new DateTime(2016, 5, 30), 50000.00M, 15, SituacaoProjeto.EmAndamento),
                new Projeto(3, "Projeto e-commerce Riachuelo", context.Usuario.Find(2), "Riachuelo", "C#", new DateTime(2016, 3, 11), new DateTime(2016, 12, 16), new DateTime(2016, 12, 20), 40000.00M, 40000.00M, 10, SituacaoProjeto.Concluido),
                new Projeto(4, "Projeto lojas Renner", context.Usuario.Find(3), "Renner", "Java", new DateTime(2016, 1, 21), new DateTime(2016, 11, 13), 30000.00M, 10, SituacaoProjeto.EmAndamento),
                new Projeto(5, "Revista online", context.Usuario.Find(3), "Abril", "Android", new DateTime(2016, 2, 1), new DateTime(2016, 5, 22), new DateTime(2016, 3, 23), 11000.00M, 33500.00M, 4, SituacaoProjeto.Cancelado),
                new Projeto(6, "Contra-cheque online", context.Usuario.Find(4), "CWI", "Java", new DateTime(2016, 12, 14), new DateTime(2016, 12, 21), 20000.00M, 3, SituacaoProjeto.EmAndamento),
                new Projeto(7, "Maturidade de projetos", context.Usuario.Find(4), "CWI", "C#", new DateTime(2016, 12, 14), new DateTime(2016, 12, 21), 20000.00M, 2, SituacaoProjeto.EmAndamento),
                new Projeto(8, "Inscrições do Crescer", context.Usuario.Find(4), "CWI", "C#", new DateTime(2016, 12, 14), new DateTime(2016, 12, 21), 20000.00M, 3, SituacaoProjeto.EmAndamento)
                );
            context.SaveChanges();

            context.Recurso.AddOrUpdate(r => r.Id,
                new Patrimonio(1, "100001", TipoRecurso.Fisico, 300.00M, SituacaoRecurso.Indisponivel, "Notebook Inspiron", "Dell", new DateTime(2015, 12, 5), 3000.00M, 10),
                new Patrimonio(2, "100002", TipoRecurso.Fisico, 450.00M, SituacaoRecurso.Disponivel, "Desktop", "Dell", new DateTime(2013, 2, 1), 4500.00M, 10),
                new Patrimonio(3, "100003", TipoRecurso.Fisico, 100.00M, SituacaoRecurso.Disponivel, "Monitor", "Dell", new DateTime(2015, 12, 5), 500.00M, 5),
                new Patrimonio(4, "100004", TipoRecurso.Fisico, 230.00M, SituacaoRecurso.Disponivel, "Notebook Vostro", "Dell", new DateTime(2015, 12, 5), 3500.00M, 15),
                new Compartilhado(5, "VM Interna", TipoRecurso.Logico, 1500.00M, SituacaoRecurso.Indisponivel, "10.10.1.1", true, 1000.00M, 8, 200000.00M, true, true),
                new Compartilhado(6, "Base de dados", TipoRecurso.Logico, 500.00M, SituacaoRecurso.Disponivel, "11.2.150.1", true, 10000.00M, 4, 5000000.00M, true, true),
                new Compartilhado(7, "Servidor fisico", TipoRecurso.Fisico, 1500.00M, SituacaoRecurso.Indisponivel, "128.10.1.1", true, 25000.00M, 8, 3000000.00M, false, false),
                new Servico(8, "Visual Studio Profissional", TipoRecurso.Logico, 2000.00M, SituacaoRecurso.Indisponivel, "Licença profissional do VS.", TipoServico.Licenca),
                new Servico(9, "TFS", TipoRecurso.Logico, 1500.00M, SituacaoRecurso.Disponivel, "Licença TFS.", TipoServico.Licenca),
                new Servico(10, "Windows Server", TipoRecurso.Logico, 1800.00M, SituacaoRecurso.Disponivel, "Licença Windows Server.", TipoServico.Licenca),
                new Servico(11, "Microsoft Vision", TipoRecurso.Logico, 1350.00M, SituacaoRecurso.Indisponivel, "Licença Microsoft Vision.", TipoServico.Licenca),
                new Servico(12, "VM Amazon", TipoRecurso.Logico, 2000, SituacaoRecurso.Indisponivel, "VM Amazon.", TipoServico.Servico),
                new Servico(13, "VM Azure", TipoRecurso.Logico, 3400.00M, SituacaoRecurso.Disponivel, "VM Microsoft Azure.", TipoServico.Servico)
                );
            context.SaveChanges();

            context.ControleRecurso.AddOrUpdate(c => c.Id,
                new ControleRecurso(1, context.Projeto.Find(1), context.Recurso.Find(1), new DateTime(2016, 12, 3), new DateTime(2016, 12, 20)),
                new ControleRecurso(2, context.Projeto.Find(1), context.Recurso.Find(8), new DateTime(2016, 10, 1), new DateTime(2016, 10, 31)),
                new ControleRecurso(3, context.Projeto.Find(2), context.Recurso.Find(5), new DateTime(2016, 3, 10), new DateTime(2016, 4, 11)),
                new ControleRecurso(4, context.Projeto.Find(2), context.Recurso.Find(7), new DateTime(2016, 4, 3), new DateTime(2016, 5, 3)),
                new ControleRecurso(5, context.Projeto.Find(3), context.Recurso.Find(11), new DateTime(2016, 3, 11), new DateTime(2016, 8, 13)),
                new ControleRecurso(6, context.Projeto.Find(3), context.Recurso.Find(12), new DateTime(2016, 12, 1), new DateTime(2016, 12, 14))
                );

        }
    }
}
