﻿using ControleCustos.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleCustos.Dominio;
using System.Collections;
using ControleCustos.Dominio.Enum;

namespace ControleCustos.Tests.Dominio
{
    public class ControleRecursoRepositorioMock : IControleRecursoRepositorio
    {
        IList<ControleRecurso> listaControleRecursos;

        public ControleRecursoRepositorioMock()
        {
            this.listaControleRecursos = new List<ControleRecurso>();

            Projeto projeto = new Projeto(1, "Coca-cola", new Usuario(), "Coca-cola", "C#", new DateTime(2016, 11, 1), new DateTime(2016, 12, 5), 1000M, 12, SituacaoProjeto.Novo);
            Projeto projeto2 = new Projeto(2, "Sicredi", new Usuario(), "Sicredi", "Java", new DateTime(2016, 11, 1), new DateTime(2016, 12, 5), 1000M, 12, SituacaoProjeto.Novo);

            this.listaControleRecursos.Add(new ControleRecurso(1,
                projeto,
                new Patrimonio(1, "Notebook", TipoRecurso.Fisico, 100M, SituacaoRecurso.Disponivel, "Inspiron", "Dell", DateTime.Now, 1000M, 10),
                new DateTime(2016, 11, 10),
                new DateTime(2016, 12, 2)));
            this.listaControleRecursos.Add(new ControleRecurso(2,
                projeto2,
                new Patrimonio(1, "Notebook", TipoRecurso.Fisico, 100M, SituacaoRecurso.Disponivel, "Inspiron", "Dell", DateTime.Now, 1000M, 10),
                new DateTime(2016, 12, 1),
                new DateTime(2016, 12, 10)));
            this.listaControleRecursos.Add(new ControleRecurso(3,
                projeto2,
                new Compartilhado(1, "VM Interna", TipoRecurso.Fisico, 1000M, SituacaoRecurso.Disponivel, "10.10.1.1", true, 1000.00M, 1000, 100, true, true),
                new DateTime(2016, 11, 1),
                new DateTime(2016, 11, 10)));
        }

        public ControleRecurso Buscar(int id)
        {
            return this.listaControleRecursos.FirstOrDefault(c => c.Id == id);
        }

        public IList<ControleRecurso> Listar(Projeto projeto)
        {
            return this.listaControleRecursos.Where(c => c.Projeto.Id == projeto.Id).ToList();
        }

        public IList<ControleRecurso> Listar(Projeto projeto, DateTime dataInicio, DateTime dataFim)
        {
            return this.listaControleRecursos.Where(
                    c => c.Projeto.Id == projeto.Id
                    && dataInicio <= c.DataFim
                    && c.DataInicio <= dataFim
            ).ToList();
        }

        public void Inserir(ControleRecurso controleRecurso)
        {
            listaControleRecursos.Add(controleRecurso);
        }

        public void Atualizar(ControleRecurso controleRecurso)
        {
            for (int i = 0; i < listaControleRecursos.Count; i++)
            {
                if (listaControleRecursos[i].Id == controleRecurso.Id)
                {
                    listaControleRecursos[i] = controleRecurso;
                    break;
                }
            }
        }
    }
}