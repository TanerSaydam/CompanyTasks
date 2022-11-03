using VehicleWebApi.Models.Abstract;

namespace VehicleWebApi.Models
{
    public class Car : Vehicle
    {
        public bool Wheels { get; set; } = true;
        public bool HeadLights { get; set; } = true;
    }
}
