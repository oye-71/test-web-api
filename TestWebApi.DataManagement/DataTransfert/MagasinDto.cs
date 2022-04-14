using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.DataManagement.Models;

namespace TestWebApi.DataManagement.DataTransfert
{
    public class MagasinDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public static Expression<Func<Magasin, MagasinDto>> Projection
        {
            get => x => new MagasinDto
            {
                Id = x.Id,
                Name = x.Name,
                Location = x.Location
            };
        }

        public static MagasinDto FromEntity(Magasin entity)
        {
            return Projection.Compile().Invoke(entity);
        }

        public static Magasin Populate(MagasinDto Magasin, Magasin entity = null)
        {
            if (entity == null)
                entity = new Magasin();

            entity.Location = Magasin.Location;
            entity.Name = Magasin.Name;
            return entity;
        }
    }
}
