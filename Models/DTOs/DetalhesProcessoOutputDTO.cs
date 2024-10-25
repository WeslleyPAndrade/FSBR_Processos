using System.ComponentModel.DataAnnotations;

namespace FSBR_Processos.Models.DTOs
{
    public class DetalhesProcessoOutputDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NPU { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataVisualizacao { get; set; }
        public string UF { get; set; }
        public string Municipio { get; set; }
    }
}
