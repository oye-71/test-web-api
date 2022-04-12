using TestWebApi.DataManagement.DataTransfert;

namespace TestWebApi.Business.Interfacage.Services
{
    public interface IOrdinateurService
    {
        public Task<OrdinateurDto> GetOrdinateurById(Guid id);
        public Task<IEnumerable<OrdinateurDto>> GetAllOrdinateurs();
        public Task AddOrdinateur(OrdinateurDto ordinateur);
    }
}
