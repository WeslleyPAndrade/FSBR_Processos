using FSBR_Processos.Domain.Interfaces;
using FSBR_Processos.Models;
using FSBR_Processos.Models.DTOs;
using FSBR_Processos.Repository.Interfaces;
using FSBR_Processos.Services.Interfaces;


namespace FSBR_Processos.Domain
{
    public class ProcessosDomain : IProcessosDomain
    {
        private readonly IIBGEService _IBGEService;
        private readonly IProcessoRepository _ProcessoRepository;
        public ProcessosDomain(IIBGEService IBGEService, IProcessoRepository processoRepository)
        {
            _IBGEService = IBGEService;
            _ProcessoRepository = processoRepository;
        }

        public async Task<ProcessoOutputDTO> ObterTodosProcessos(ProcessoInputDTO input)
        {
            var listaProcessos = await _ProcessoRepository.ObterTodosProcessosAsync();

            var processos = listaProcessos
            .OrderBy(p => p.DataCadastro)
            .Skip((input.Page - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToList();

            var totalProcessos = listaProcessos.Count();

            var totalPages = (int)Math.Ceiling((double)totalProcessos / input.PageSize);

            return new ProcessoOutputDTO(input.Page, totalPages, processos);
        }

        public async Task CriarProcesso(CriarProcessoInputDTO model)
        {
            var processo = new Processo
            {
                Nome = model.NomeProcesso,
                NPU = model.NPU,
                UF = model.UF,
                Municipio = model.Municipio,
                DataCadastro = DateTime.Now
            };

            await _ProcessoRepository.CriarProcessoAsync(processo);
            await _ProcessoRepository.SalvarAsync();
        }

        public async Task SalvarEditacaoProcesso(EditarProcessoInputDTO model)
        {
            var listaMunicipios = await _IBGEService.GetMunicipiosByUF(model.UF);
            var municipio = listaMunicipios.Where(m => m.Nome == model.Municipio.Split(".")[0]).FirstOrDefault();

            var processo = new Processo
            {
                Id = model.Id,
                Nome = model.NomeProcesso,
                NPU = model.NPU,
                UF = model.UF,
                Municipio = $"{municipio.Nome}.{municipio.Id}",
                DataCadastro = DateTime.Now
            };

            await _ProcessoRepository.EditarProcessoAsync(processo);
            await _ProcessoRepository.SalvarAsync();
        }

        public async Task<EditarProcessoInputDTO> EditarProcesso(int id)
        {
            var processo = await _ProcessoRepository.ObterProcessoPorIdAsync(id);
            if (processo != null)
            {
                var processoEditar = new EditarProcessoInputDTO()
                {
                    Id = processo.Id,
                    NomeProcesso = processo.Nome,
                    NPU = processo.NPU, 
                    UF = processo.UF,
                    Municipio = processo.Municipio.Split(".")[0],
                    DataVisualizacao = processo.DataVisualizacao
                };

                return processoEditar;
            }

            return new EditarProcessoInputDTO();
        }

        public async Task DeletarProcesso(int id)
        {
            await _ProcessoRepository.DeletarProcessoAsync(id);
        }

        public async Task<DetalhesProcessoOutputDTO> ObterProcessoPorId(int id)
        {
            var processo = await _ProcessoRepository.ObterProcessoPorIdAsync(id);
            if (processo != null)
            {
                var detalhesProcessoOutput = new DetalhesProcessoOutputDTO()
                {
                    Id = processo.Id,
                    Nome = processo.Nome,
                    NPU = processo.NPU,
                    DataCadastro = processo.DataCadastro,
                    DataVisualizacao = processo.DataVisualizacao,
                    UF = processo.UF,
                    Municipio = processo.Municipio
                };

                return detalhesProcessoOutput;
            }

            return new DetalhesProcessoOutputDTO();
        }

        public async Task<IEnumerable<UF>> RecuperarUFs()
        {
            return await _IBGEService.GetUFs();
        }

        public async Task<IEnumerable<Municipio>> GetMunicipiosByUF(string uf)
        {
            return await _IBGEService.GetMunicipiosByUF(uf);
        }

        public async Task ConfirmarVisualizacaoAsync(int id)
        {
            await _ProcessoRepository.ConfirmarVisualizacaoAsync(id);
        }

    }
}
