using ControleCustos.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using ControleCustos.Dominio;
using ControleCustos.Dominio.Enum;

namespace ControleCustos.Tests.Dominio
{
    public class ProjetoRepositorioMock : IProjetoRepositorio
    {
        private static List<Projeto> lista = new List<Projeto>() {
        new Projeto(1, "Máquinas da felicidade", new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente), "Coca-cola", "C#", new DateTime(2016, 9, 20), new DateTime(2016, 12, 20), 100000.00M, 10, SituacaoProjeto.EmAndamento) { },
        new Projeto(2, "Projeto site do Sicredi", new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente), "Sicredi", "Java", new DateTime(2016, 3, 5), new DateTime(2016, 5, 30), 50000.00M, 15, SituacaoProjeto.EmAndamento){ },
        new Projeto(3, "Projeto e-commerce Riachuelo", new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente), "Riachuelo", "C#", new DateTime(2016, 3, 11), new DateTime(2016, 12, 16), new DateTime(2016, 12, 20), 40000.00M, 40000.00M, 10, SituacaoProjeto.Concluido){ },
        new Projeto(4, "Projeto lojas Renner", new Usuario(1, "Cassio Farias Machado", "cassio@cwi.com.br", "446ffac81f08f558556ea6d61a49dc17", Permissao.Gerente), "Renner", "Java", new DateTime(2016, 1, 21), new DateTime(2016, 11, 13), 30000.00M, 10, SituacaoProjeto.EmAndamento){ },
        new Projeto(5, "Revista online", new Usuario(2, "Mateus Ramos", "mateus@cwi.com.br", "4d821c9cc14e6ed34342b96bc4dab7d2", Permissao.Gerente), "Abril", "Android", new DateTime(2016, 2, 1), new DateTime(2016, 5, 22), new DateTime(2016, 3, 23), 11000.00M, 33500.00M, 4, SituacaoProjeto.Cancelado){ },
        new Projeto(6, "Contra-cheque online", new Usuario(2, "Mateus Ramos", "mateus@cwi.com.br", "4d821c9cc14e6ed34342b96bc4dab7d2", Permissao.Gerente), "CWI", "Java", new DateTime(2016, 12, 14), new DateTime(2016, 12, 21), 20000.00M, 3, SituacaoProjeto.EmAndamento){ },
        new Projeto(7, "Maturidade de projetos", new Usuario(2, "Mateus Ramos", "mateus@cwi.com.br", "4d821c9cc14e6ed34342b96bc4dab7d2", Permissao.Gerente), "CWI", "C#", new DateTime(2016, 12, 14), new DateTime(2016, 12, 21), 20000.00M, 2, SituacaoProjeto.EmAndamento){ },
        new Projeto(8, "Inscrições do Crescer", new Usuario(2, "Mateus Ramos", "mateus@cwi.com.br", "4d821c9cc14e6ed34342b96bc4dab7d2", Permissao.Gerente), "CWI", "C#", new DateTime(2016, 12, 14), new DateTime(2016, 12, 21), 20000.00M, 3, SituacaoProjeto.EmAndamento)

    };
        public void Atualizar(Projeto projeto)
        {
            lista[lista.FindIndex(p => p.Id == projeto.Id)] = projeto;
        }

        public Projeto Buscar(int id)
        {
            return lista.Find(p => p.Id == id);
        }

        public void Inserir(Projeto projeto)
        {
            lista.Add(projeto);
        }

        public IList<Projeto> Listar(string filtro)
        {
            return lista.Where(p => filtro == "" || (p.Cliente.ToLower().Contains(filtro.ToLower()) ||
                                    p.Nome.ToLower().Contains(filtro.ToLower()) ||
                                    p.Gerente.Nome.ToLower().Contains(filtro.ToLower()))).ToList();
        }

        public IList<Projeto> ListarPorGerente(Usuario gerente, string filtro)
        {
            throw new NotImplementedException();
        }

        public IList<Projeto> ListarProjetosAtivos()
        {
            throw new NotImplementedException();
        }

        public IList<Projeto> ListarProjetosEncerrados()
        {
            throw new NotImplementedException();
        }
    }
}
