using TestWebApi.Business.Interfacage.Services;
using TestWebApi.DataManagement.DataTransfert;
using TestWebApi.DataManagement.Interfacage.Repositories;

namespace TestWebApi.Business.Services
{
    public class MagasinService : IMagasinService
    {
        private readonly IMagasinRepository _magasinRepository;

        public MagasinService(IMagasinRepository magasinRepository)
        {
            _magasinRepository = magasinRepository;
        }

        public async Task<IEnumerable<MagasinDto>> GetAllMagasinDtos() => await _magasinRepository.GetAllMagasinDtos();

        public async Task<IEnumerable<MagasinWithComputersDto>> GetAllMagasinWithComputers() => await _magasinRepository.GetAllMagasinsWithStock();
    }
}
