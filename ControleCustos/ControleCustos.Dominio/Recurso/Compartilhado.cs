using ControleCustos.Dominio.Enum;
using System.ComponentModel.DataAnnotations;

namespace ControleCustos.Dominio
{
    public class Compartilhado : Recurso
    {
        public string EnderecoIp { get; private set; }

        public bool BaseDeDados { get; private set; }

        public decimal EspacoEmDisco { get; private set; }

        public int Processadores { get; private set; }

        public decimal Memoria { get; private set; }

        public bool BackupDiario { get; private set; }

        public bool BackupIncremental { get; private set; }

        public Compartilhado() { }

        public Compartilhado(int id, 
            string nome,
            TipoRecurso tipoRecurso, 
            decimal valorMensal,
            SituacaoRecurso situacao,
            string enderecoIp,
            bool baseDeDados,
            decimal espacoEmDisco,
            int processadores, 
            decimal memoria,
            bool backupDiario,
            bool backupIncremental) : 
            base(id, nome, tipoRecurso, valorMensal, situacao)
        {
            this.EnderecoIp = enderecoIp;
            this.BaseDeDados = baseDeDados;
            this.EspacoEmDisco = espacoEmDisco;
            this.Processadores = processadores;
            this.Memoria = memoria;
            this.BackupDiario = backupDiario;
            this.BackupIncremental = backupIncremental;
        }
    }
}
