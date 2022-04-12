using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.DataManagement.Models;

namespace TestWebApi.DataManagement.Interfacage.Repositories
{
    public interface IStockRepository : IRepository<Stock>
    {
        public Task<Stock> GetStockByComputerIdAndMagasinId(Guid computerId, Guid magasinId);
    }
}
