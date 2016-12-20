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
        void Inserir(ControleRecurso controleRecurso);
    }
}
