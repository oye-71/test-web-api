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
                Ordinateurs = x.Stocks.Where(x => x.IsDispo).Select(x => new OrdinateurDto
                {
                    Id = x.Ordinateur.Id,
                    Name = x.Ordinateur.Name,
                    Brand = x.Ordinateur.Brand,
                    Price = x.Ordinateur.Price,
                })
            };
        }
    }
}
