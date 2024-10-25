using System.ComponentModel.DataAnnotations;

namespace FSBR_Processos.Models
{
    public class Processo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [RegularExpression(@"\d{7}-\d{2}.\d{4}.\d{1}.\d{2}.\d{4}", ErrorMessage = "Formato do NPU inválido")]
        public string NPU { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataVisualizacao { get; set; }
        [Required]
        public string UF { get; set; }
        [Required]
        public string Municipio { get; set; }

    }
}
