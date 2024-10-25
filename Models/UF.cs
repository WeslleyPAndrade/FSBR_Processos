namespace FSBR_Processos.Models
{
    public class UF
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public Regiao Regiao { get; set; }
    }
}
