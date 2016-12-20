using ControleCustos.Dominio.Enum;

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

        public TipoRecurso TipoRecurso { get; private set; }

        public Compartilhado() { }

        public Compartilhado(int id, 
            string nome,
            decimal valorMensal,
            SituacaoRecurso situacao,
            bool interno,
            string enderecoIp,
            bool baseDeDados,
            decimal espacoEmDisco,
            int processadores, 
            decimal memoria,
            bool backupDiario,
            bool backupIncremental,
            TipoRecurso tipoRecurso) : 
            base(id, nome, valorMensal, situacao, interno)
        {
            this.EnderecoIp = enderecoIp;
            this.BaseDeDados = baseDeDados;
            this.EspacoEmDisco = espacoEmDisco;
            this.Processadores = processadores;
            this.Memoria = memoria;
            this.BackupDiario = backupDiario;
            this.BackupIncremental = backupIncremental;
            this.TipoRecurso = tipoRecurso;
        }
    }
}
