using System.Data.Entity;
using ControleCustos.Dominio;
using ControleCustos.Dominio.Interface;
using System.Collections;
using ControleCustos.Dominio.Enum;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ControleCustos.Repositorio
{
    public class ProjetoRepositorio : IProjetoRepositorio
    {
        public Projeto Buscar(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Projeto.Include(p => p.Gerente).FirstOrDefault(p => p.Id == id);
            }
        }

        public IList<Projeto> ListarPorGerente(Usuario gerente)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Projeto> query = context.Projeto
                    .Where(p => p.Gerente.Id.Equals(gerente.Id))
                    .Include(p => p.Gerente);

                return query.ToList();
            }
        }

        public IList<Projeto> ListarProjetosEmAndamento()
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Projeto> query = context.Projeto.Where(p => p.Situacao == SituacaoProjeto.EmAndamento)
                                                           .Include("Gerente");
                return query.ToList();
            }
        }

        public IList<Projeto> ListarProjetosEncerrados()
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Projeto> query = context.Projeto.Where(p => p.Situacao == SituacaoProjeto.Cancelado 
                                                                       || p.Situacao == SituacaoProjeto.Concluido)
                                                           .Include("Gerente");
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

                return query.Include(p => p.Gerente).ToList();
            }
        }
    }
}
