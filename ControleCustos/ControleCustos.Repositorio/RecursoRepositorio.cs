using System;
using System.Data.Entity;
using ControleCustos.Dominio;
using ControleCustos.Dominio.Interface;
using System.Linq;
using System.Collections.Generic;
using ControleCustos.Dominio.Configuracao;

namespace ControleCustos.Repositorio
{
    public class RecursoRepositorio : IRecursoRepositorio
    {
        public Recurso Buscar(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Recurso.Find(id);
            }
        }
        public IList<Recurso> BuscaPaginada(Type tipo, Paginacao paginacao)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Recurso> query = context.Recurso.Where(r => r.GetType().Equals(tipo)).Skip((paginacao.PaginaDesejada - 1) * paginacao.QuantidadeDeRecursosPorPagina).Take(paginacao.QuantidadeDeRecursosPorPagina); ;
                return query.ToList();
            }
        }

        public void Inserir(Recurso recurso)
        {
            using (var context = new DatabaseContext())
            {
                context.Entry<Recurso>(recurso).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Atualizar(Recurso recurso)
        {
            using (var context = new DatabaseContext())
            {
                context.Entry<Recurso>(recurso).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
