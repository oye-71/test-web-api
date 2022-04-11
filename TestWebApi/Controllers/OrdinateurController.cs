using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ComputersDbContext _computersDbContext;
        private readonly IRepository<Ordinateur> _ordinateurRepository;

        public OrdinateurController(ComputersDbContext context, IRepository<Ordinateur> ordinateurRepository)
        {
            _computersDbContext = context;
            _ordinateurRepository = ordinateurRepository;
        }

        [HttpGet, Route("GetAllComputers")]
        public async Task<IEnumerable<OrdinateurDto>> GetAllComputers()
        {
            return (await _ordinateurRepository.GetAll()).Select(o => OrdinateurDto.FromEntity(o));
        }

        [HttpGet, Route("GetComputerById")]
        public async Task<OrdinateurDto> GetComputerById(Guid computerId)
        {
            return OrdinateurDto.FromEntity(await _ordinateurRepository.GetById(computerId));
        }

        [HttpPost, Route("AddComputer")]
        public async Task AddComputer(OrdinateurDto ordinateur)
        {
            await _ordinateurRepository.Add(OrdinateurDto.Populate(ordinateur));
            await _computersDbContext.SaveChangesAsync();
        }
    }
}
