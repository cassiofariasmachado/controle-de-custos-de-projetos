using ControleCustos.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ControleRecurso BuscarPeloNomeDoProjeto(Projeto projeto)
        {
            using (var context = new DatabaseContext())
            {
                return context.ControleRecurso.Where(c => c.Projeto.Nome.Equals(projeto.Nome)).FirstOrDefault();
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
                context.Entry<ControleRecurso>(controleRecurso).State = EntityState.Added;
                if (controleRecurso.Projeto != null)
                {
                    context.Entry<Projeto>(controleRecurso.Projeto).State = EntityState.Unchanged;
                }
                if (controleRecurso.Recurso != null)
                {
                    context.Entry<Recurso>(controleRecurso.Recurso).State = EntityState.Unchanged;
                }
                context.SaveChanges();
            }
        }

        public void Atualizar(ControleRecurso controleRecurso)
        {
            using (var context = new DatabaseContext())
            {
                context.Entry<ControleRecurso>(controleRecurso).State = EntityState.Modified;
                if (controleRecurso.Projeto != null)
                {
                    context.Entry<Projeto>(controleRecurso.Projeto).State = EntityState.Unchanged;
                }
                if (controleRecurso.Recurso != null)
                {
                    context.Entry<Recurso>(controleRecurso.Recurso).State = EntityState.Unchanged;
                }
                context.SaveChanges();
            }
        }
    }
}
