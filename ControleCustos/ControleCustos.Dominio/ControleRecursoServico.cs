using ControleCustos.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCustos.Dominio
{
    public class ControleRecursoServico
    {
        IControleRecursoRepositorio controleRecursoRepositorio;

        public ControleRecursoServico(IControleRecursoRepositorio controleRecursoRepositorio)
        {
            this.controleRecursoRepositorio = controleRecursoRepositorio;
        }

        public ControleRecurso Buscar(int id)
        {
            return this.controleRecursoRepositorio.Buscar(id);
        }

        public void Salvar(ControleRecurso controleRecurso)
        {
            if (controleRecurso.Id == 0)
            {
                this.controleRecursoRepositorio.Inserir(controleRecurso);
            }
            else
            {
                this.controleRecursoRepositorio.Atualizar(controleRecurso);
            }
        }
    }
}
