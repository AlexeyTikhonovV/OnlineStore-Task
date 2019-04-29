using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class JsonController : ODataController
    {
        private ApplicationDbContext _context; 

        public JsonController(ApplicationDbContext context)
        {
            _context = context;

            if (context.Commodity.Count() == 0)
            {
                foreach (var b in DataSource.GetGoods())
                {
                    context.Commodity.Add(b);
                }
                context.SaveChanges();
            }
        }

        //odata/Json
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_context.Commodity);
        }

        //odata/Json(1)
        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(_context.Commodity.FirstOrDefault(c => c.Id == key));
        }
    }
}
