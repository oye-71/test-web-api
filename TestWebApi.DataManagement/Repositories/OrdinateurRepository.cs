using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.DataManagement.DataTransfert;
using TestWebApi.DataManagement.DbManagement;
using TestWebApi.DataManagement.Interfacage.Repositories;
using TestWebApi.DataManagement.Models;

namespace TestWebApi.DataManagement.Repositories
{
    public class OrdinateurRepository : BaseRepository<Ordinateur>, IOrdinateurRepository
    {
        private readonly ComputersDbContext _dbContext;
        public OrdinateurRepository(ComputersDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<OrdinateurDto>> GetAllOrdinateurs()
        {
            return await _dbContext.Set<Ordinateur>()
                .Select(OrdinateurDto.Projection)
                .OrderBy(x => x.Brand)
                .ThenBy(x => x.Price)
                .ToListAsync();
        }

        public async Task<OrdinateurDto> GetOrdinateurById(Guid id)
        {
            var entity = await GetById(id);
            return OrdinateurDto.FromEntity(entity);
        }
    }
}
