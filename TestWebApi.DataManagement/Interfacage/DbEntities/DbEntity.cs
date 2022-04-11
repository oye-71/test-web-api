using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApi.DataManagement.Interfacage.DbEntities
{
    public class DbEntity : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DbEntity()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
