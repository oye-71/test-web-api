using TestWebApi.DataManagement.DataTransfert;

namespace TestWebApi.Business.Interfacage.Services
{
    public interface IOrdinateurService
    {
        Task<OrdinateurDto> GetOrdinateurById(Guid id);
        Task<IEnumerable<OrdinateurDto>> GetAllOrdinateurs();
        Task AddOrdinateur(OrdinateurDto ordinateur);
        Task<bool> AddAndActivateStock(Guid ordinateurId, Guid magasinId);
        Task OutOfStock(Guid stockId);
        Task DeleteComputerById(Guid computerId);
    }
}
