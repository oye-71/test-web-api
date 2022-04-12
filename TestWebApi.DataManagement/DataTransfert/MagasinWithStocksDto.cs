using System.Linq.Expressions;
using TestWebApi.DataManagement.Models;

namespace TestWebApi.DataManagement.DataTransfert
{
    public class MagasinWithComputersDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<OrdinateurDto> Ordinateurs { get; set; }

        public static Expression<Func<Magasin, MagasinWithComputersDto>> Projection
        {
            get => x => new MagasinWithComputersDto
            {
                Id = x.Id,
                Name = x.Name,
                Location = x.Location,
                Ordinateurs = x.Stocks.Select(x => x.Ordinateur).Select(o => new OrdinateurDto
                {
                    Id = o.Id,
                    Name = o.Name,
                    Brand = o.Brand,
                    Price = o.Price,
                })
            };
        }
    }
}
