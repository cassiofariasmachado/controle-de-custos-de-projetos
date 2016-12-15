using System;
using System.Data.Entity;
using ControleCustos.Dominio;
using ControleCustos.Dominio.Interface;

namespace ControleCustos.Repositorio.RecursoRepositorio
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
