using ControleCustos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleCustos.Models
{
    public class ControleRecursoModel
    {

        public ControleRecursoModel(Recurso recurso, Projeto projeto)
        {
            this.IdRecurso = recurso.Id;
            this.IdProjeto = projeto.Id;
            this.NomeRecurso = recurso.Nome;
            this.NomeProjeto = projeto.Nome;
        }

        public int IdRecurso { get; private set; }
        public int IdProjeto { get; private set; }
        public string NomeProjeto { get; private set; }
        public string NomeRecurso { get; private set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}