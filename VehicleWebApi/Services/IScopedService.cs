using VehicleWebApi.Models.Abstract;

namespace VehicleWebApi.Services
{
    public interface IScopedService
    {
        Vehicle SelectVehicle(int id, string type);
    }
}
