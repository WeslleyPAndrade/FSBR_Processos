namespace FSBR_Processos.Models.DTOs
{
    public class ProcessoInputDTO
    {
        public int PageSize { get; set; }
        public int Page { get; set; }

        public ProcessoInputDTO(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
