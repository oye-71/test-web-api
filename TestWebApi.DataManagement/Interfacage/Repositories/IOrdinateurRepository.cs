using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
