using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
