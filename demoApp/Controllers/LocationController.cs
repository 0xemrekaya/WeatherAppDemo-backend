using DemoApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public LocationController(DemoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Location> Get()
        {
            return _context.Locations.ToList();
        }

        [HttpPut]
        public Location Put([FromBody] Location request)
        {
            if (request.ID > 0)
            {
                var record = _context.Locations.FirstOrDefault(c => c.ID == request.ID);
                record = request;

                _context.Entry(record).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }

            return request;
        }

        [HttpPost]
        public Location Post([FromBody] Location request)
        {
            _context.Locations.Add(request);
            _context.SaveChanges();
            return request;
        }

        [HttpDelete("{id}")]
        public bool Delete(long id)
        {
            if (id > 0)
            {
                var record = _context.Locations.FirstOrDefault(c => c.ID == id);
                if (record != null)
                {
                    _context.Remove(record);
                    _context.SaveChanges();
                    return true;
                }
            }

            return false;
        }
    }
}