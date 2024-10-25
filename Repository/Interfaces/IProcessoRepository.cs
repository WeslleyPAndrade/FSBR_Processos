using FSBR_Processos.Models;

namespace FSBR_Processos.Repository.Interfaces
{
    public interface IProcessoRepository
    {
        Task<IEnumerable<Processo>> ObterTodosProcessosAsync();
        Task<Processo> ObterProcessoPorIdAsync(int id);
        Task CriarProcessoAsync(Processo processo);
        Task EditarProcessoAsync(Processo processo);
        Task DeletarProcessoAsync(int id);
        Task SalvarAsync();
        Task ConfirmarVisualizacaoAsync(int id);
    }
}
