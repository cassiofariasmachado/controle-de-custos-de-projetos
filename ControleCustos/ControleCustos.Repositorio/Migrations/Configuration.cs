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

            var projeto1 = new Projeto(1, "Time Tracking", cassio, "Coca-cola", "Java", new DateTime(2016, 9, 20), new DateTime(2016, 12, 20), 100000.00M, 10, SituacaoProjeto.EmAndamento);
            var projeto2 = new Projeto(2, "PE Online", mateus, "Sicredi", "Java", new DateTime(2016, 3, 5), new DateTime(2016, 5, 30), 50000.00M, 15, SituacaoProjeto.EmAndamento);
            var projeto3 = new Projeto(3, "Agendamento Sala de Reunião", gabriel, "Riachuelo", "C#", new DateTime(2016, 3, 11), new DateTime(2016, 12, 16), new DateTime(2016, 12, 20), 40000.00M, 40000.00M, 10, SituacaoProjeto.Concluido);
            var projeto4 = new Projeto(4, "Maturidade Online", nunes, "Renner", "Java", new DateTime(2016, 1, 21), new DateTime(2016, 11, 13), 30000.00M, 10, SituacaoProjeto.EmAndamento);
            var projeto5 = new Projeto(5, "Contracheque online", gerente, "Abril", "Android", new DateTime(2016, 2, 1), new DateTime(2016, 5, 22), new DateTime(2016, 3, 23), 11000.00M, 33500.00M, 4, SituacaoProjeto.Cancelado);
            var projeto6 = new Projeto(6, "Alocações Parciais - LT's", gerente, "CWI", "Java", new DateTime(2016, 12, 14), new DateTime(2016, 12, 21), 20000.00M, 3, SituacaoProjeto.EmAndamento);
            var projeto7 = new Projeto(7, "Inscrições do Crescer", gerente, "CWI", "C#", new DateTime(2016, 12, 14), new DateTime(2016, 12, 21), 20000.00M, 3, SituacaoProjeto.EmAndamento);

            context.Projeto.AddOrUpdate(p => p.Id,
                projeto1,
                projeto2,
                projeto3,
                projeto4,
                projeto5,
                projeto6,
                projeto7);
            context.SaveChanges();

            var patrimonio1 = new Patrimonio(1, "002828", 5000 / 36, SituacaoRecurso.Disponivel, true, "Latitude E5470", "Dell", new DateTime(2016, 2, 1), 5000, 36);
            var patrimonio2 = new Patrimonio(2, "002830", 7000 / 36, SituacaoRecurso.Disponivel, true, "Latitude E5470", "Dell", new DateTime(2016, 2, 1), 7000, 36);
            var patrimonio3 = new Patrimonio(3, "001345", 1800 / 12, SituacaoRecurso.Disponivel, true, "Inspiron 1060", "Dell", new DateTime(2016, 2, 1), 1800, 12);
            var patrimonio4 = new Patrimonio(4, "003993", 800 / 24, SituacaoRecurso.Disponivel, true, "Monitor ´23 XD", "Dell", new DateTime(2016, 7, 1), 800, 24);
            var patrimonio5 = new Patrimonio(5, "003994", 450 / 24, SituacaoRecurso.Disponivel, true, "Monitor ´17 XD", "Dell", new DateTime(2016, 7, 1), 450, 24);
            var patrimonio6 = new Patrimonio(6, "003995", 800 / 24, SituacaoRecurso.Disponivel, true, "Monitor ´23 XD", "Dell", new DateTime(2016, 7, 1), 800, 24);
            var compartilhado1 = new Compartilhado(7, "SQLDEV\\2012 - Dev01", 15, SituacaoRecurso.Disponivel, true, "10.0.100.15", false, 1, 5, 4, true, true, TipoRecurso.Logico);
            var compartilhado2 = new Compartilhado(8, "SQLDEV\\2012 - Tst01", 80, SituacaoRecurso.Disponivel, true, "10.0.100.15", true, 120, 4, 8, false, false, TipoRecurso.Logico);
            var compartilhado3 = new Compartilhado(9, "IIS - AppWeb", 10, SituacaoRecurso.Disponivel, true, "10.0.100.20", false, 1, 2, 4, true, true, TipoRecurso.Logico);
            var compartilhado4 = new Compartilhado(10, "Oracle 12c - Dev04", 68, SituacaoRecurso.Disponivel, true, "10.0.100.10", true, 400, 7, 4, true, true, TipoRecurso.Logico);
            var servico1 = new Servico(11, "Visual Studio Profissional", 2000, SituacaoRecurso.Indisponivel, true, "Licença profissional do VS.", TipoServico.Licenca);
            var servico2 = new Servico(12, "TFS", 1500, SituacaoRecurso.Disponivel, true, "Licença TFS.", TipoServico.Licenca);
            var servico3 = new Servico(13, "Windows Server", 1800, SituacaoRecurso.Disponivel, true, "Licença Windows Server.", TipoServico.Licenca);
            var servico4 = new Servico(14, "Microsoft Vision", 1350, SituacaoRecurso.Indisponivel, true, "Licença Microsoft Vision.", TipoServico.Licenca);
            var servico5 = new Servico(15, "VM Amazon", 2000, SituacaoRecurso.Indisponivel, false, "VM Amazon.", TipoServico.Servico);
            var servico6 = new Servico(16, "VM Azure", 3400, SituacaoRecurso.Disponivel, false, "VM Microsoft Azure.", TipoServico.Servico);

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


            UnidadeTecnica unidade1 = new UnidadeTecnica(1, "CWI-POA", "POA", "Porto Alegre");
            UnidadeTecnica unidade2 = new UnidadeTecnica(2, "CWI-SL", "SL", "São Leopoldo");
            UnidadeTecnica unidade3 = new UnidadeTecnica(3, "CWI-NH", "NH", "Novo Hamburgo");
            UnidadeTecnica unidade4 = new UnidadeTecnica(4, "CWI-SP", "SP", "São Paulo");
            context.UnidadeTecnica.AddOrUpdate(u => u.Id,
               unidade1,
               unidade2,
               unidade3,
               unidade4);
            context.SaveChanges();

            context.Colaboradores.AddOrUpdate(c => c.Id,
                new Colaboradores(1, 100, new DateTime(2016, 8, 1), unidade1),
                new Colaboradores(2, 120, new DateTime(2016, 9, 1), unidade1),
                new Colaboradores(3, 150, new DateTime(2016, 10, 1), unidade1),
                new Colaboradores(4, 200, new DateTime(2016, 10, 1), unidade1),
                new Colaboradores(5, 210, new DateTime(2016, 11, 1), unidade1),
                new Colaboradores(6, 400, new DateTime(2016, 10, 1), unidade2));
            context.SaveChanges();

            context.Custo.AddOrUpdate(c => c.Id,
                new Custo(1, "Agua", 100, unidade1, new DateTime(2016, 8, 1)),
                new Custo(2, "Agua", 100, unidade1, new DateTime(2016, 9, 1)),
                new Custo(3, "Agua", 100, unidade1, new DateTime(2016, 10, 1)),
                new Custo(4, "Agua", 100, unidade1, new DateTime(2016, 11, 1)),
                new Custo(5, "Agua", 100, unidade1, new DateTime(2016, 12, 1)),
                new Custo(6, "Luz", 100, unidade2, new DateTime(2016, 8, 1)));
            context.SaveChanges();
        }
    }
}
