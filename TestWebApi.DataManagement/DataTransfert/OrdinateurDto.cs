using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.DataManagement.Models;

namespace TestWebApi.DataManagement.DataTransfert
{
    public class OrdinateurDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }

        public static Expression<Func<Ordinateur, OrdinateurDto>> Projection
        {
            get => x => new OrdinateurDto
            {
                Name = x.Name,
                Brand = x.Brand,
                Price = x.Price
            };
        }

        public static OrdinateurDto FromEntity(Ordinateur entity)
        {
            return Projection.Compile().Invoke(entity);
        }

        public static Ordinateur Populate(OrdinateurDto ordinateur, Ordinateur entity = null)
        {
            if(entity == null)
                entity = new Ordinateur();

            entity.Brand = ordinateur.Brand;
            entity.Price = ordinateur.Price;
            entity.Name = ordinateur.Name;
            return entity;
        }
    }
}
