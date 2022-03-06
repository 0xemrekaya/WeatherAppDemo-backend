using demoApp.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp.Entities
{
    public class WeatherForecast : BaseEntity
    {
        [ForeignKey("Location")]
        public long LocationID { get; set; }
        public Location? Location { get; set; }
        public decimal MinTemp { get; set; }
        public decimal MaxTemp { get; set; }
        public decimal Humidity { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
    }
}
