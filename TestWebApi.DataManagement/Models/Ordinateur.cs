using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.DataManagement.Interfacage.DbEntities;

namespace TestWebApi.DataManagement.Models
{
    public class Ordinateur : DbEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
