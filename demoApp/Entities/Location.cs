using demoApp.Entities;

namespace DemoApp.Entities
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
