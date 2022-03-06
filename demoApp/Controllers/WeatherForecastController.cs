using DemoApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public WeatherForecastController(DemoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<WeatherForecast> Get()
        {
            return _context.WeatherForecasts.Include(c => c.Location).ToList();
        }

        [HttpPut]
        public WeatherForecast Put([FromBody] WeatherForecast request)
        {
            if (request.ID > 0)
            {
                var record = _context.WeatherForecasts.FirstOrDefault(c => c.ID == request.ID);

                if (record != null)
                {
                    record = request;
                    _context.Entry(record).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }

            return request;
        }

        [HttpPost]
        public WeatherForecast Post([FromBody] WeatherForecast request)
        {
            request.CreatedDateTime = DateTime.Now.ToUniversalTime();
            _context.WeatherForecasts.Add(request);
            _context.SaveChanges();

            var result = _context.WeatherForecasts.Include(c => c.Location).FirstOrDefault(c => c.ID == request.ID);
            return result;
        }

        [HttpDelete("{id}")]
        public bool Delete(long id)
        {
            if (id > 0)
            {
                var record = _context.WeatherForecasts.FirstOrDefault(c => c.ID == id);
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