using ControleCustos.Dominio.Recurso.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCustos.Dominio.Recurso
{
    public class RecursoServico
    {
        IRecursoRepositorio recursoRepositorio;

        public RecursoServico(IRecursoRepositorio recursoRepositorio)
        {
            this.recursoRepositorio = recursoRepositorio;
        }

        public Classe.Recurso Buscar(int id)
        {
            return recursoRepositorio.Buscar(id);
        }

        public void Salvar(Classe.Recurso recurso)
        {
            if (recurso.Id == 0)
            {
                recursoRepositorio.Inserir(recurso);
            } else
            {
                recursoRepositorio.Atualizar(recurso);
            }
        }
    }
}
