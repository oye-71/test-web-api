using Microsoft.EntityFrameworkCore;
using TestWebApi.DataManagement.DataTransfert;
using TestWebApi.DataManagement.DbManagement;
using TestWebApi.DataManagement.Interfacage.Repositories;
using TestWebApi.DataManagement.Models;

namespace TestWebApi.DataManagement.Repositories
{
    public class MagasinRepository : BaseRepository<Magasin>, IMagasinRepository
    {
        private readonly ComputersDbContext _dbContext;

        public MagasinRepository(ComputersDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MagasinWithComputersDto>> GetAllMagasinsWithStock()
        {
            return await _dbContext.Set<Magasin>()
                .Where(x => x.Stocks.Where(x => x.IsDispo).Count() > 0)
                .Select(MagasinWithComputersDto.Projection)
                .ToListAsync();
        }

        public async Task<IEnumerable<MagasinDto>> GetAllMagasinDtos()
        {
            return await _dbContext.Set<Magasin>()
                .Select(MagasinDto.Projection)
                .OrderBy(m => m.Name)
                .ToListAsync();
        }
    }
}
