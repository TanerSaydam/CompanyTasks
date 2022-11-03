using VehicleWebApi.Models;
using VehicleWebApi.Models.Abstract;

namespace VehicleWebApi.Services
{
    public class ScopedService : IScopedService
    {
        List<Car> CarList = new List<Car>()
        {
            new Car(){Id=0,Wheels= true, HeadLights = true, Color = "Red"},
            new Car(){Id=1,Wheels= true, HeadLights = true, Color = "Blue"},
            new Car(){Id=2,Wheels= true, HeadLights = true, Color = "Black"},
            new Car(){Id=3,Wheels= true, HeadLights = true, Color = "White"},
        };

        List<Bus> BusList = new List<Bus>()
        {
            new Bus(){Id=0,Color = "Red"},
            new Bus(){Id=1,Color = "Blue"},
            new Bus(){Id=2,Color = "Black"},
            new Bus(){Id=3,Color = "White"},
        };

        List<Boat> BoatList = new List<Boat>()
        {
            new Boat(){Id=0,Color = "Red"},
            new Boat(){Id=1,Color = "Blue"},
            new Boat(){Id=2,Color = "Black"},
            new Boat(){Id=3,Color = "White"},
        };

        public Vehicle SelectVehicle(int id, string type)
        {
            if (type == "Bus")
                return BusList.Where(p => p.Id == id).FirstOrDefault();
            
            if (type == "Car")
                return CarList.Where(p => p.Id == id).FirstOrDefault();

            if (type == "Boat")
                return BoatList.Where(p => p.Id == id).FirstOrDefault();

            return null;            
        }
    }
}
