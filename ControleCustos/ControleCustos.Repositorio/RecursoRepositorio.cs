using System.Data.Entity;
using ControleCustos.Dominio;
using ControleCustos.Dominio.Interface;
using System.Linq;
using System.Collections.Generic;

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
        public IList<Recurso> BuscaPaginadaRecursoCompartilhados(int pagina, int quantidade)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Recurso> query = from b in context.Recurso.OfType<Compartilhado>() select b;
                return query.OrderBy(r => r.Nome).Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
            }
        }

        public IList<Recurso> BuscaPaginadaServicos(int pagina, int quantidade)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Recurso> query = from b in context.Recurso.OfType<Servico>() select b;
                return query.OrderBy(r => r.Nome).Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
            }
        }

        public IList<Recurso> BuscaPaginadaPatrimonios(int pagina, int quantidade)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Recurso> query = from b in context.Recurso.OfType<Patrimonio>() select b;
                return query.OrderBy(r => r.Nome).Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
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
