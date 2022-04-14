using TestWebApi.Business.Interfacage.Services;
using TestWebApi.DataManagement.DataTransfert;
using TestWebApi.DataManagement.Interfacage.Repositories;
using TestWebApi.DataManagement.Models;

namespace TestWebApi.Business.Services
{
    public class OrdinateurService : IOrdinateurService
    {
        private readonly IOrdinateurRepository _ordinateurRepository;
        private readonly IStockRepository _stockRepository;

        public OrdinateurService(IOrdinateurRepository ordinateurRepository, IStockRepository stockRepository)
        {
            _ordinateurRepository = ordinateurRepository;
            _stockRepository = stockRepository;
        }

        public async Task AddOrdinateur(OrdinateurDto ordinateur)
        {
            Ordinateur entity = new Ordinateur();
            entity = OrdinateurDto.Populate(ordinateur, entity);
            await _ordinateurRepository.Add(entity);
        }

        public async Task<IEnumerable<OrdinateurDto>> GetAllOrdinateurs() => await _ordinateurRepository.GetAllOrdinateurs();

        public async Task<OrdinateurDto> GetOrdinateurById(Guid id) => await _ordinateurRepository.GetOrdinateurById(id);

        public async Task AddAndActivateStock(Guid ordinateurId, Guid magasinId)
        {
            var stock = await _stockRepository.GetStockByComputerIdAndMagasinId(ordinateurId, magasinId);
            if (stock == null)
            {
                stock = new Stock { MagasinId = magasinId, OrdinateurId = ordinateurId, IsDispo = true };
            }
            else
            {
                stock.IsDispo = true;
            }
            await _stockRepository.AddOrUpdate(stock);
        }

        public async Task OutOfStock(Guid stockId)
        {
            var stock = await _stockRepository.GetById(stockId);
            stock.IsDispo = false;
            await _stockRepository.Update(stock);
        }

        public async Task DeleteComputerById(Guid computerId)
        {
            var entity = await _ordinateurRepository.GetById(computerId);
            if (entity != null)
            {
                await _ordinateurRepository.Delete(entity);
            }
        }
    }
}
