namespace ControleCustos.Dominio.Recurso.Classe
{
    public class RecursoCompartilhado : Recurso
    {
        public string EnderecoIp { get; set; }
        public bool BaseDeDados { get; set; }
        public string EspacoEmDisco { get; set; }
        public string Processadores { get; set; }
        public string Memoria { get; set; }
        public bool BackupDiario { get; set; }
        public bool BackupIncremental { get; set; }
    }
}
