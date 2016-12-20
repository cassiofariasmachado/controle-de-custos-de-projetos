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
            var cassio = new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente);
            var mateus = new Usuario(2, "Mateus Ramos", "mateus@cwi.com.br", "4d821c9cc14e6ed34342b96bc4dab7d2", Permissao.Gerente);
            var gabriel = new Usuario(3, "Gabriel Rosa", "gabriel@cwi.com.br", "fa7446a73be910732a1d368d377f8356", Permissao.Gerente);
            var nunes = new Usuario(4, "Andre Nunes", "nunes@cwi.com.br", "f89f55479e2e21d547e1890f76166ead", Permissao.Gerente);
            var gerente = new Usuario(5, "Gerente", "gerente@cwi.com.br", "acbe533904a5277d7de721d5d6c09a1f", Permissao.Gerente);
            var administrador = new Usuario(6, "Administrador", "administrador@cwi.com.br", "a383e7ad2d5203bee24c29da3806fcb8", Permissao.Administrador);

            context.Usuario.AddOrUpdate(u => u.Id,
                cassio,
                mateus,
                gabriel,
                nunes,
                gerente,
                administrador);
            context.SaveChanges();

            var projeto1 = new Projeto(1, "Máquinas da felicidade", cassio, "Coca-cola", "C#", new DateTime(2016, 9, 20), new DateTime(2016, 12, 20), 100000.00M, 10, SituacaoProjeto.EmAndamento);
            var projeto2 = new Projeto(2, "Projeto site do Sicredi", mateus, "Sicredi", "Java", new DateTime(2016, 3, 5), new DateTime(2016, 5, 30), 50000.00M, 15, SituacaoProjeto.EmAndamento);
            var projeto3 = new Projeto(3, "Projeto e-commerce Riachuelo", gabriel, "Riachuelo", "C#", new DateTime(2016, 3, 11), new DateTime(2016, 12, 16), new DateTime(2016, 12, 20), 40000.00M, 40000.00M, 10, SituacaoProjeto.Concluido);
            var projeto4 = new Projeto(4, "Projeto lojas Renner", nunes, "Renner", "Java", new DateTime(2016, 1, 21), new DateTime(2016, 11, 13), 30000.00M, 10, SituacaoProjeto.EmAndamento);
            var projeto5 = new Projeto(5, "Revista online", gerente, "Abril", "Android", new DateTime(2016, 2, 1), new DateTime(2016, 5, 22), new DateTime(2016, 3, 23), 11000.00M, 33500.00M, 4, SituacaoProjeto.Cancelado);
            var projeto6 = new Projeto(6, "Contra-cheque online", gerente, "CWI", "Java", new DateTime(2016, 12, 14), new DateTime(2016, 12, 21), 20000.00M, 3, SituacaoProjeto.EmAndamento);
            var projeto7 = new Projeto(7, "Maturidade de projetos", gerente, "CWI", "C#", new DateTime(2016, 12, 14), new DateTime(2016, 12, 21), 20000.00M, 2, SituacaoProjeto.EmAndamento);
            var projeto8 = new Projeto(8, "Inscrições do Crescer", gerente, "CWI", "C#", new DateTime(2016, 12, 14), new DateTime(2016, 12, 21), 20000.00M, 3, SituacaoProjeto.EmAndamento);

            context.Projeto.AddOrUpdate(p => p.Id,
                projeto1,
                projeto2,
                projeto3,
                projeto4,
                projeto5,
                projeto6,
                projeto7,
                projeto8);
            context.SaveChanges();

            var patrimonio1 = new Patrimonio(1, "100001", TipoRecurso.Fisico, 300.00M, SituacaoRecurso.Indisponivel, true, "Notebook Inspiron", "Dell", new DateTime(2015, 12, 5), 3000.00M, 10);
            var patrimonio2 = new Patrimonio(2, "100002", TipoRecurso.Fisico, 450.00M, SituacaoRecurso.Disponivel, true, "Desktop", "Dell", new DateTime(2013, 2, 1), 4500.00M, 10);
            var patrimonio3 = new Patrimonio(3, "100003", TipoRecurso.Fisico, 100.00M, SituacaoRecurso.Disponivel, true, "Monitor", "Dell", new DateTime(2015, 12, 5), 500.00M, 5);
            var patrimonio4 = new Patrimonio(4, "100004", TipoRecurso.Fisico, 230.00M, SituacaoRecurso.Disponivel, true, "Notebook Vostro", "Dell", new DateTime(2015, 12, 5), 3500.00M, 15);
            var compartilhado1 = new Compartilhado(5, "VM Interna", TipoRecurso.Logico, 1500.00M, SituacaoRecurso.Indisponivel, true, "10.10.1.1", true, 1000.00M, 8, 200000.00M, true, true);
            var compartilhado2 = new Compartilhado(6, "Base de dados", TipoRecurso.Logico, 500.00M, SituacaoRecurso.Disponivel, true, "11.2.150.1", true, 10000.00M, 4, 5000000.00M, true, true);
            var compartilhado3 = new Compartilhado(7, "Servidor fisico", TipoRecurso.Fisico, 1500.00M, SituacaoRecurso.Indisponivel, true, "128.10.1.1", true, 25000.00M, 8, 3000000.00M, false, false);
            var servico1 = new Servico(8, "Visual Studio Profissional", TipoRecurso.Logico, 2000.00M, SituacaoRecurso.Indisponivel, true, "Licença profissional do VS.", TipoServico.Licenca);
            var servico2 = new Servico(9, "TFS", TipoRecurso.Logico, 1500.00M, SituacaoRecurso.Disponivel, true, "Licença TFS.", TipoServico.Licenca);
            var servico3 = new Servico(10, "Windows Server", TipoRecurso.Logico, 1800.00M, SituacaoRecurso.Disponivel, true, "Licença Windows Server.", TipoServico.Licenca);
            var servico4 = new Servico(11, "Microsoft Vision", TipoRecurso.Logico, 1350.00M, SituacaoRecurso.Indisponivel, true, "Licença Microsoft Vision.", TipoServico.Licenca);
            var servico5 = new Servico(12, "VM Amazon", TipoRecurso.Logico, 2000, SituacaoRecurso.Indisponivel, false, "VM Amazon.", TipoServico.Servico);
            var servico6 = new Servico(13, "VM Azure", TipoRecurso.Logico, 3400.00M, SituacaoRecurso.Disponivel, false, "VM Microsoft Azure.", TipoServico.Servico);

            context.Recurso.AddOrUpdate(r => r.Id,
                patrimonio1,
                patrimonio2,
                patrimonio3,
                patrimonio4,
                compartilhado1,
                compartilhado2,
                compartilhado3,
                servico1,
                servico2,
                servico3,
                servico4,
                servico5,
                servico6);
            context.SaveChanges();

            context.ControleRecurso.AddOrUpdate(c => c.Id,
                new ControleRecurso(1, projeto1, patrimonio1, new DateTime(2016, 12, 3), new DateTime(2016, 12, 20)),
                new ControleRecurso(2, projeto1, compartilhado1, new DateTime(2016, 10, 1), new DateTime(2016, 10, 31)),
                new ControleRecurso(3, projeto2, patrimonio4, new DateTime(2016, 3, 10), new DateTime(2016, 4, 11)),
                new ControleRecurso(4, projeto2, compartilhado2, new DateTime(2016, 4, 3), new DateTime(2016, 5, 3)),
                new ControleRecurso(5, projeto3, servico5, new DateTime(2016, 3, 11), new DateTime(2016, 8, 13)),
                new ControleRecurso(6, projeto3, servico1, new DateTime(2016, 12, 1), new DateTime(2016, 12, 14)));
        }
    }
}
