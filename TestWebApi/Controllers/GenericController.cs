using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        private readonly GenericDbContext _context;

        public GenericController(GenericDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetGenericItems")]
        public IEnumerable<GenericItem> GetGenericItems()
        {
            return _context.GenericItems.ToList();
        }

        [HttpPost]
        [Route("AddGenericItem")]
        public void AddOne(GenericItem item)
        {
            if(item == null)
                throw new ArgumentNullException(nameof(item));

            _context.GenericItems.Add(item);
            _context.SaveChanges();
        }
    }
}
