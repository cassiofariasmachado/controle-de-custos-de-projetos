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
    }
}
