using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApi.DataManagement.Models
{
    public class Stock
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid OrdinateurId { get; set; }
        public Guid MagasinId { get; set; }
        public bool IsDispo { get; set; }

        public Ordinateur Ordinateur { get; set; }
        public Magasin Magasin { get; set; }
    }
}
