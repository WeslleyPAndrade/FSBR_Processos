namespace FSBR_Processos.Models
{
    public class Municipio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Microregiao Microregiao { get; set; }
        public RegiaoImediata RegiaoImediata { get; set; }
    }
}
