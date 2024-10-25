namespace FSBR_Processos.Models.DTOs
{
    public class ProcessoOutputDTO
    {
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<Processo> Processos { get; set; }

        public ProcessoOutputDTO(int page, int totalPages, IEnumerable<Processo> processos)
        {
            Page = page;
            TotalPages = totalPages;
            Processos = processos;
        }
    }
}
