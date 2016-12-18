using System.Data.Entity;
using ControleCustos.Dominio;
using ControleCustos.Dominio.Interface;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ControleCustos.Repositorio
{
    public class ProjetoRepositorio : IProjetoRepositorio
    {
        public Projeto Buscar(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Projeto.Find(id);
            }
        }

        public IList<Projeto> ListarPorGerente(Usuario gerente)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Projeto> query = context.Projeto.Where(p => p.Gerente.Id.Equals(gerente.Id));

                return query.ToList();
            }
        }

        public void Inserir(Projeto projeto)
        {
            using (var context = new DatabaseContext())
            {
                context.Entry<Projeto>(projeto).State = EntityState.Added;
                if (projeto.Gerente != null)
                {
                    context.Entry<Usuario>(projeto.Gerente).State = EntityState.Unchanged;
                }
                context.SaveChanges();
            }
        }

        public void Atualizar(Projeto projeto)
        {
            using (var context = new DatabaseContext())
            {
                context.Entry<Projeto>(projeto).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public IList<Projeto> Listar()
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Projeto> query = context.Projeto;

                return query.ToList();
            }
        }
    }
}
