using TestWebApi.DataManagement.DataTransfert;
using TestWebApi.DataManagement.Models;

namespace TestWebApi.DataManagement.Interfacage.Repositories
{
    public interface IOrdinateurRepository : IRepository<Ordinateur>
    {
        public Task<IEnumerable<OrdinateurDto>> GetAllOrdinateurs();
        public Task<OrdinateurDto> GetOrdinateurById(Guid id); 
    }
}
