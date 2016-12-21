using System.Data.Entity;
using ControleCustos.Dominio;
using ControleCustos.Dominio.Interface;
using System.Linq;
using System.Collections.Generic;
using ControleCustos.Dominio.Enum;

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
        public IList<Compartilhado> BuscaPaginadaRecursoCompartilhados(int pagina, int quantidade)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Compartilhado> query = from recurso in context.Recurso.OfType<Compartilhado>() select recurso;
                return query.Where(r => r.Situacao == SituacaoRecurso.Disponivel).OrderBy(r => r.Nome).Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
            }
        }
        public int CompartilhadoCount()
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Recurso> query = from recurso in context.Recurso.OfType<Compartilhado>() select recurso;
                return query.Where(r => r.Situacao == SituacaoRecurso.Disponivel).Count();
            }
        }

        public IList<Servico> BuscaPaginadaServicos(int pagina, int quantidade)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Servico> query = from recurso in context.Recurso.OfType<Servico>() select recurso;
                return query.Where(r => r.Situacao == SituacaoRecurso.Disponivel).OrderBy(r => r.Nome).Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
            }
        }

        public int ServicoCount()
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Recurso> query = from recurso in context.Recurso.OfType<Servico>() select recurso;
                return query.Where(r => r.Situacao == SituacaoRecurso.Disponivel).Count();
            }
        }

        public IList<Patrimonio> BuscaPaginadaPatrimonios(int pagina, int quantidade)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Patrimonio> query = from recurso in context.Recurso.OfType<Patrimonio>() select recurso;
                return query.Where(r => r.Situacao == SituacaoRecurso.Disponivel).OrderBy(r => r.Nome).Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
            }
        }

        public int PatrimonioCount()
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Recurso> query = from recurso in context.Recurso.OfType<Patrimonio>() select recurso;
                return query.Where(r => r.Situacao == SituacaoRecurso.Disponivel).Count();
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
