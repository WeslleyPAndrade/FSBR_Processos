using FSBR_Processos.Models;

namespace FSBR_Processos.Services.Interfaces
{
    public interface IIBGEService
    {
        Task<IEnumerable<UF>> GetUFs();
        Task<IEnumerable<Municipio>> GetMunicipiosByUF(string uf);
    }
}
