using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.DataManagement.Interfacage.DbEntities;

namespace TestWebApi.DataManagement.Models
{
    public class Stock : DbEntity
    {
        public Guid OrdinateurId { get; set; }
        public Guid MagasinId { get; set; }
        public bool IsDispo { get; set; }

        public virtual Ordinateur Ordinateur { get; set; }
        public virtual Magasin Magasin { get; set; }
    }
}
