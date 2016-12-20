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

        public IList<Projeto> ListarPorGerente(Usuario gerente, string filtro)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Projeto> query = context.Projeto
                    .Where(
                            p => p.Gerente.Id.Equals(gerente.Id)
                            && (filtro == "" ||
                                    (p.Cliente.ToLower().Contains(filtro.ToLower()) ||
                                    p.Nome.ToLower().Contains(filtro.ToLower()) ||
                                    p.Gerente.Nome.ToLower().Contains(filtro.ToLower()))))
                         .Include(p => p.Gerente);

                return query.ToList();
            }
        }

        public IList<Projeto> ListarProjetosAtivos()
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Projeto> query = context.Projeto.Where(p => p.Situacao == SituacaoProjeto.EmAndamento 
                                                                       || p.Situacao == SituacaoProjeto.Novo)
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

        public IList<Projeto> Listar(string filtro)
        {
            using (var context = new DatabaseContext())
            {
                IQueryable<Projeto> query = context.Projeto
                     .Where(p => filtro == "" || (p.Cliente.ToLower().Contains(filtro.ToLower()) ||
                                    p.Nome.ToLower().Contains(filtro.ToLower()) ||
                                    p.Gerente.Nome.ToLower().Contains(filtro.ToLower())));

                return query.Include(p => p.Gerente).ToList();
            }
        }
    }
}
