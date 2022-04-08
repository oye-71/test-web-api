using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApi.DataManagement.Models
{
    public class Ordinateur
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}
