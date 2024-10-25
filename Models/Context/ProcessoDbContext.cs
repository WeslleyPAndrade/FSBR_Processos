using Microsoft.EntityFrameworkCore;

namespace FSBR_Processos.Models.Context
{
    public class ProcessoDbContext : DbContext
    {
        public ProcessoDbContext(DbContextOptions<ProcessoDbContext> options) : base(options) { }

        public DbSet<Processo> Processos { get; set; }

    }
}
