using TestWebApi.DataManagement.DataTransfert;

namespace TestWebApi.Business.Interfacage.Services
{
    public interface IMagasinService
    {
        Task<IEnumerable<MagasinWithComputersDto>> GetAllMagasinWithComputers();
        Task<IEnumerable<MagasinDto>> GetAllMagasinDtos();
    }
}
