using ControleCustos.Dominio.Configuracao;
using System;
using System.Collections.Generic;

namespace ControleCustos.Dominio.Interface
{
    public interface IRecursoRepositorio
    {
        Recurso Buscar(int id);
        void Inserir(Recurso recurso);
        void Atualizar(Recurso recurso);
        IList<Recurso> BuscaPaginada(Type tipo, Paginacao paginacao);
    }
}