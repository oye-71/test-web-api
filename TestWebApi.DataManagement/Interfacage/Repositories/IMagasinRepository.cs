using TestWebApi.DataManagement.DataTransfert;
using TestWebApi.DataManagement.Models;

namespace TestWebApi.DataManagement.Interfacage.Repositories
{
    public interface IMagasinRepository : IRepository<Magasin>
    {
        public Task<IEnumerable<MagasinWithComputersDto>> GetAllMagasinsWithStock();
    }
}
