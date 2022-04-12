using Microsoft.EntityFrameworkCore;
using TestWebApi.DataManagement.DataTransfert;
using TestWebApi.DataManagement.DbManagement;
using TestWebApi.DataManagement.Interfacage.Repositories;
using TestWebApi.DataManagement.Models;

namespace TestWebApi.DataManagement.Repositories
{
    public class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        private readonly ComputersDbContext _dbContext;

        public StockRepository(ComputersDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Stock> GetStockByComputerIdAndMagasinId(Guid computerId, Guid magasinId)
        {
            return await _dbContext.Set<Stock>().FirstOrDefaultAsync(s => s.OrdinateurId == computerId && s.MagasinId == magasinId);
        }
    }
}
