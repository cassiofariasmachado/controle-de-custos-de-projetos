using ControleCustos.Dominio.Configuracao;
using ControleCustos.Dominio.Interface;
using System;
using System.Collections.Generic;

namespace ControleCustos.Dominio
{
    public class RecursoServico
    {
        private IRecursoRepositorio recursoRepositorio;
        private IServicoDeConfiguracao servicoDeConfiguracao;

        public RecursoServico(IRecursoRepositorio recursoRepositorio, IServicoDeConfiguracao servicoDeConfiguracao)
        {
            this.recursoRepositorio = recursoRepositorio;
            this.servicoDeConfiguracao = servicoDeConfiguracao;
        }

        public Recurso Buscar(int id)
        {
            return recursoRepositorio.Buscar(id);
        }

        public IList<Recurso> BuscaPaginada(Type tipo, int pagina)
        {
            int quantidadeDeRecursosPorPagina = this.servicoDeConfiguracao.QuantidadeDeRecursosPorPagina;

            Paginacao paginacao = new Paginacao()
            {
                PaginaDesejada = pagina,
                QuantidadeDeRecursosPorPagina = quantidadeDeRecursosPorPagina
            };

            return this.recursoRepositorio.BuscaPaginada(tipo, paginacao);
        }

        public void Salvar(Recurso recurso)
        {
            if (recurso.Id == 0)
            {
                recursoRepositorio.Inserir(recurso);
            }
            else
            {
                recursoRepositorio.Atualizar(recurso);
            }
        }
    }
}
