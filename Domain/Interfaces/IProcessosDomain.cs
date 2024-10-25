using FSBR_Processos.Models;
using FSBR_Processos.Models.DTOs;

namespace FSBR_Processos.Domain.Interfaces
{
    public interface IProcessosDomain
    {
        Task<ProcessoOutputDTO> ObterTodosProcessos(ProcessoInputDTO input);
        Task CriarProcesso(CriarProcessoInputDTO model);
        Task SalvarEditacaoProcesso(EditarProcessoInputDTO model);
        Task<EditarProcessoInputDTO> EditarProcesso(int id);
        Task DeletarProcesso(int id);
        Task<DetalhesProcessoOutputDTO> ObterProcessoPorId(int id);
        Task ConfirmarVisualizacaoAsync(int id);

        Task<IEnumerable<UF>> RecuperarUFs();
        Task<IEnumerable<Municipio>> GetMunicipiosByUF(string uf);
    }
}
