using ControleCustos.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ControleCustos.Dominio;
using System.Data.Entity;

namespace ControleCustos.Repositorio
{
    public class ControleRecursoRepositorio : IControleRecursoRepositorio
    {
        public ControleRecurso Buscar(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.ControleRecurso.Find(id);
            }
        }

        public IList<ControleRecurso> Listar(Projeto projeto)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<ControleRecurso> query = context.ControleRecurso.Where(c => c.Projeto.Id == projeto.Id)
                                                                           .Include("Recurso")
                                                                           .Include("Projeto");
                return query.ToList();
            }
        }

        public IList<ControleRecurso> ListarPatrimonio(Projeto projeto)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<ControleRecurso> query = context.ControleRecurso.Where(
                    c => c.Projeto.Id == projeto.Id && c.Recurso is Patrimonio)
                    .Include("Recurso")
                    .Include("Projeto");
                return query.ToList();
            }
        }

        public IList<ControleRecurso> ListarCompartilhado(Projeto projeto)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<ControleRecurso> query = context.ControleRecurso.Where(
                    c => c.Projeto.Id == projeto.Id && c.Recurso is Compartilhado)
                    .Include("Recurso")
                    .Include("Projeto");
                return query.ToList();
            }
        }

        public IList<ControleRecurso> ListarServico(Projeto projeto)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<ControleRecurso> query = context.ControleRecurso.Where(
                    c => c.Projeto.Id == projeto.Id && c.Recurso is Servico)
                    .Include("Recurso")
                    .Include("Projeto");
                return query.ToList();
            }
        }

        public IList<ControleRecurso> Listar(Projeto projeto, DateTime dataInicio, DateTime dataFim)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<ControleRecurso> query = context.ControleRecurso.Where(c => c.Projeto.Id == projeto.Id
                                                                                       && dataInicio >= c.DataInicio
                                                                                       && c.DataInicio <= dataFim)
                                                                           .Include("Recurso")
                                                                           .Include("Projeto");
                return query.ToList();
            }
        }

        public void Inserir(ControleRecurso controleRecurso)
        {
            using (var context = new DatabaseContext())
            {
                if (controleRecurso.Projeto != null)
                {
                    context.Entry<Projeto>(controleRecurso.Projeto).State = EntityState.Unchanged;
                }
                if (controleRecurso.Recurso != null)
                {
                    context.Entry<Recurso>(controleRecurso.Recurso).State = EntityState.Unchanged;
                }
                context.Entry<ControleRecurso>(controleRecurso).State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
