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

        public IList<T> BuscarRecursosPaginados<T>(int pagina, int quantidade) where T : Recurso
        {
            using (var context = new DatabaseContext())
            {
                return context.Recurso.OfType<T>()
                        .Where(recurso => recurso.Situacao == SituacaoRecurso.Disponivel)
                        .OrderBy(recurso => recurso.Nome)
                        .Skip((pagina - 1) * quantidade)
                        .Take(quantidade)
                        .ToList();                
            }
        }
        public int BuscarQuantidadeRecursos<T>() where T : Recurso
        {
            using (var context = new DatabaseContext())
            {
                return context.Recurso.OfType<T>().Count(r => r.Situacao == SituacaoRecurso.Disponivel);
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
