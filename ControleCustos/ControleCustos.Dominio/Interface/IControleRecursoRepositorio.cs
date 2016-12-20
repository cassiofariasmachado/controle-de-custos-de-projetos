using System;
using System.Collections.Generic;

namespace ControleCustos.Dominio.Interface
{
    public interface IControleRecursoRepositorio
    {
        ControleRecurso Buscar(int id);
        IList<ControleRecurso> Listar(Projeto projeto);
        IList<ControleRecurso> ListarPatrimonio(Projeto projeto);
        IList<ControleRecurso> ListarCompartilhado(Projeto projeto);
        IList<ControleRecurso> ListarServico(Projeto projeto);
        IList<ControleRecurso> Listar(Projeto projeto, DateTime dataInicio, DateTime dataFim);
        int QuantidadeDeRecursosInternosPorProjeto(Projeto projeto);
        int QuantidadeDeRecursosInternosNaoUtilizadosPorProjetosAtivos();
        void Inserir(ControleRecurso controleRecurso);
    }
}
