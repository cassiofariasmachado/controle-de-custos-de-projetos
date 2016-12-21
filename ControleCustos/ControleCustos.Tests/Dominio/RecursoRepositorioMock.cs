using ControleCustos.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;

namespace ControleCustos.Tests.Dominio
{
    public class RecursoRepositorioMock : IRecursoRepositorio
    {
        private static List<Recurso> lista = new List<Recurso>()
        {
        new Patrimonio(1, "100001", 300.00M, SituacaoRecurso.Indisponivel, true, "Notebook Inspiron", "Dell", new DateTime(2015, 12, 5), 3000.00M, 10) {},
        new Patrimonio(2, "100002", 450.00M, SituacaoRecurso.Disponivel, true, "Desktop", "Dell", new DateTime(2013, 2, 1), 4500.00M, 10){},
        new Patrimonio(3, "100003", 100.00M, SituacaoRecurso.Disponivel, true, "Monitor", "Dell", new DateTime(2015, 12, 5), 500.00M, 5){},
        new Patrimonio(4, "100004", 230.00M, SituacaoRecurso.Disponivel, true, "Notebook Vostro", "Dell", new DateTime(2015, 12, 5), 3500.00M, 15){},
        new Compartilhado(5, "VM Interna", 1500.00M, SituacaoRecurso.Indisponivel, true, "10.10.1.1", true, 1000.00M, 8, 200000.00M, true, true, TipoRecurso.Logico){},
        new Compartilhado(6, "Base de dados", 500.00M, SituacaoRecurso.Disponivel, true, "11.2.150.1", true, 10000.00M, 4, 5000000.00M, true, true, TipoRecurso.Logico){},
        new Compartilhado(7, "Servidor fisico", 1500.00M, SituacaoRecurso.Indisponivel, true, "128.10.1.1", true, 25000.00M, 8, 3000000.00M, false, false, TipoRecurso.Fisico){},
        new Servico(8, "Visual Studio Profissional", 2000.00M, SituacaoRecurso.Indisponivel, true, "Licença profissional do VS.", TipoServico.Licenca){},
        new Servico(9, "TFS", 1500.00M, SituacaoRecurso.Disponivel, true, "Licença TFS.", TipoServico.Licenca){},
        new Servico(10, "Windows Server", 1800.00M, SituacaoRecurso.Disponivel, true, "Licença Windows Server.", TipoServico.Licenca){},
        new Servico(11, "Microsoft Vision", 1350.00M, SituacaoRecurso.Indisponivel, true, "Licença Microsoft Vision.", TipoServico.Licenca){},
        new Servico(12, "VM Amazon", 2000, SituacaoRecurso.Indisponivel, false, "VM Amazon.", TipoServico.Servico){},
        new Servico(13, "VM Azure", 3400.00M, SituacaoRecurso.Disponivel, false, "VM Microsoft Azure.", TipoServico.Servico)
        };
        public void Atualizar(Recurso recurso)
        {
            lista[lista.FindIndex(p => p.Id == recurso.Id)] = recurso;
        }

        public IList<Recurso> BuscaPaginadaPatrimonios(int pagina, int quantidade)
        {
            return lista.Where(r => r is Patrimonio && r.Situacao == SituacaoRecurso.Disponivel).OrderBy(r => r.Nome).Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
        }

        public IList<Recurso> BuscaPaginadaRecursoCompartilhados(int pagina, int quantidade)
        {
            return lista.Where(r => r is Compartilhado && r.Situacao == SituacaoRecurso.Disponivel).OrderBy(r => r.Nome).Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
        }

        public IList<Recurso> BuscaPaginadaServicos(int pagina, int quantidade)
        {
            return lista.Where(r => r is Servico && r.Situacao == SituacaoRecurso.Disponivel).OrderBy(r => r.Nome).Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
        }

        public Recurso Buscar(int id)
        {
            return lista.Find(r => r.Id == id);
        }

        public int CompartilhadoCount()
        {
            return lista.Where(r => r is Compartilhado).ToList().Count;
        }

        public void Inserir(Recurso recurso)
        {
            lista.Add(recurso);
        }

        public int PatrimonioCount()
        {
            return lista.Where(r => r is Patrimonio).ToList().Count;
        }

        public int ServicoCount()
        {
            return lista.Where(r => r is Servico).ToList().Count;
        }
    }
}
