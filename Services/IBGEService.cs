using FSBR_Processos.Services.Interfaces;
using FSBR_Processos.Models;

namespace FSBR_Processos.Services
{
    public class IBGEService : IIBGEService
    {
        private readonly HttpClient _httpClient;

        public IBGEService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UF>> GetUFs()
        {
            var apiUrl = "https://servicodados.ibge.gov.br/api/v1/localidades/estados?orderBy=nome";

            try
            {
                var listaUFs = await _httpClient.GetFromJsonAsync<IEnumerable<UF>>(apiUrl);

                if (listaUFs == null)
                {
                    return Enumerable.Empty<UF>();
                }

                return listaUFs;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"API IBGE indisponível - Erro ao obter UFs: {ex.Message}");
                return Enumerable.Empty<UF>();
            }
        }

        public async Task<IEnumerable<Municipio>> GetMunicipiosByUF(string uf)
        {
            var apiUrl = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{uf}/municipios";
            try
            {
                var listaMunicipios = await _httpClient.GetFromJsonAsync<IEnumerable<Municipio>>(apiUrl);

                if (listaMunicipios == null)
                {
                    return Enumerable.Empty<Municipio>();
                }

                return listaMunicipios;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API IBGE indisponível - Erro ao obter municípios: {ex.Message}");
                return Enumerable.Empty<Municipio>();
            }
        }


    }
}
