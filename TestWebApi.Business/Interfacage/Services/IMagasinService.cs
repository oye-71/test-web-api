using TestWebApi.DataManagement.DataTransfert;

namespace TestWebApi.Business.Interfacage.Services
{
    public interface IMagasinService
    {
        public Task<IEnumerable<MagasinWithComputersDto>> GetAllMagasinWithComputers();
    }
}
