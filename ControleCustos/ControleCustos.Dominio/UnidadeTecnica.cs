namespace ControleCustos.Dominio
{
    public class UnidadeTecnica
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sigla { get; private set; }
        public string Local { get; private set; }
        public UnidadeTecnica(int id, string nome, string sigla, string local)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sigla = sigla;
            this.Local = local;
        }
    }
}
