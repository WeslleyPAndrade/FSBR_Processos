using FSBR_Processos.Models.Context;
using FSBR_Processos.Models;
using FSBR_Processos.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FSBR_Processos.Repository
{
    public class ProcessoRepository : IProcessoRepository
    {
        private readonly ProcessoDbContext _context;

        public ProcessoRepository(ProcessoDbContext context)
        {
            _context = context;
        }

        public async Task CriarProcessoAsync(Processo processo)
        {
            await _context.Processos.AddAsync(processo);
        }
        public async Task EditarProcessoAsync(Processo processo)
        {
            _context.Processos.Update(processo);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarProcessoAsync(int id)
        {
            var processo = await _context.Processos.FindAsync(id);
            if (processo != null)
            {
                _context.Processos.Remove(processo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Processo>> ObterTodosProcessosAsync()
        {
            return await _context.Processos.ToListAsync();
        }

        public async Task<Processo> ObterProcessoPorIdAsync(int id)
        {
            return await _context.Processos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task SalvarAsync()
        {
            await _context.SaveChangesAsync();
        }


        public async Task ConfirmarVisualizacaoAsync(int id)
        {
            var processo = await _context.Processos.FindAsync(id);
            processo.DataVisualizacao = DateTime.Now;
            _context.Processos.Update(processo);
            await _context.SaveChangesAsync();
        }
    }
}
