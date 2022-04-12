using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApi.Business.Interfacage.Services;
using TestWebApi.DataManagement.DataTransfert;
using TestWebApi.DataManagement.DbManagement;
using TestWebApi.DataManagement.Interfacage.Repositories;
using TestWebApi.DataManagement.Models;

namespace TestWebApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdinateurController : ControllerBase
    {
        private readonly IOrdinateurService _ordinateurService;
        private readonly IMagasinService _magasinService;

        public OrdinateurController(IOrdinateurService ordinateurService, IMagasinService magasinService)
        {
            _ordinateurService = ordinateurService;
            _magasinService = magasinService;
        }

        [HttpGet, Route("GetAllComputers")]
        public async Task<IEnumerable<OrdinateurDto>> GetAllComputers()
        {
            return await _ordinateurService.GetAllOrdinateurs();
        }

        [HttpGet, Route("GetComputerById")]
        public async Task<OrdinateurDto> GetComputerById(Guid computerId)
        {
            return await _ordinateurService.GetOrdinateurById(computerId);
        }

        [HttpPost, Route("AddComputer")]
        public async Task AddComputer(OrdinateurDto ordinateur)
        {
            await _ordinateurService.AddOrdinateur(ordinateur);
        }

        [HttpGet, Route("GetAllMagasinWithComputers")]
        public async Task<IEnumerable<MagasinWithComputersDto>> GetAllMagasinWithComputers()
        {
            return await _magasinService.GetAllMagasinWithComputers();
        }
    }
}
